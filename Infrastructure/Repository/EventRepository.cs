using Domain.Dto.Commom;
using Domain.Dto.Event;
using Domain.Entities.Event;
using Domain.Mappers.Event;
using Domain.Repository;
using Infrastructure.Setup;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly DatabaseContext _databaseContext;

        public EventRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<EventDto> New(EventDto input)
        {
            var entity = input.MapToEntity();
            var result = await _databaseContext.Events.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return result.Entity.MapToDto();
        }

        public async Task<EventDto> Update(long id, UpdateInputDto input)
        {
            var entity = await _databaseContext.Events.Where(e => e.Id == id).Include(e => e.EventAttendants).FirstOrDefaultAsync();

            if (entity != null)
            {
                var updatedEntity = entity.UpdateEntity(input);

                if (input.EventAttendants != null)
                {
                    var entityAttendantIds = entity.EventAttendants.Select(e => e.AttendantId).ToList();
                    var inputAttendantIds = input.EventAttendants.Select(e => e.AttendantId).ToList();

                    var idsToRemove = entityAttendantIds.Except(inputAttendantIds).ToList();
                    var idsToInsert = inputAttendantIds.Except(entityAttendantIds).ToList();

                    var attendantsToRemove = _databaseContext.EventAttendants.Where(e => idsToRemove.Contains(e.AttendantId));

                    var teste = await attendantsToRemove.ToListAsync();

                    _databaseContext.EventAttendants.RemoveRange(attendantsToRemove);

                    var attentantsAlreadyInserted = _databaseContext.EventAttendants.Where(e => idsToInsert.Contains(e.AttendantId));

                    var idsAlreadyInserted = attentantsAlreadyInserted.Select(e => e.AttendantId);

                    idsToInsert = idsToInsert.Except(idsAlreadyInserted).ToList();

                    var attendantsToInsert = idsToInsert.Select(id => new EventAttendantEntity()
                    {
                        AttendantId = id,
                        EventId = entity.Id
                    });

                    await _databaseContext.EventAttendants.AddRangeAsync(attendantsToInsert);
                }

                await _databaseContext.SaveChangesAsync();
                return entity.MapToDto();
            }

            return default;
        }

        public async Task<bool> Delete(long id)
        {
            var entity = await _databaseContext.Events.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (entity == null)
            {
                return false;
            }

            _databaseContext.Events.Remove(entity);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByParams(DeleteByParamsInputDto input)
        {
            var query = _databaseContext.Events.AsQueryable();

            if (input.ClientId != null)
            {
                query = query.Where(e => e.ClientId == input.ClientId);
            }

            var entities = await query.ToListAsync();

            if (!entities.Any())
            {
                return false;
            }

            _databaseContext.Events.RemoveRange(entities);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task Accept(AcceptInputDto input)
        {
            var entity = await _databaseContext.EventAttendants.Where(e => e.EventId == input.EventId).Where(e => e.AttendantId == input.AttendantId).FirstOrDefaultAsync();
            var eventEntity = await _databaseContext.Events.Where(e => e.Id == input.EventId).FirstOrDefaultAsync();

            if (entity != null)
            {
                if (input.Accepted != null)
                {
                    entity.Accepted = (bool)input.Accepted;
                }
                else
                {
                    entity.Accepted = !entity.Accepted;
                }

                if (eventEntity != null)
                {
                    eventEntity.UpdatedAt = DateTime.UtcNow;
                }

                await _databaseContext.SaveChangesAsync();
            }
        }

        public async Task ShowUp(ShowUpInputDto input)
        {
            var entity = await _databaseContext.EventAttendants.Where(e => e.EventId == input.EventId).Where(e => e.AttendantId == input.AttendantId).FirstOrDefaultAsync();
            var eventEntity = await _databaseContext.Events.Where(e => e.Id == input.EventId).FirstOrDefaultAsync();

            if (entity != null)
            {
                if (input.ShowedUp != null)
                {
                    entity.ShowedUp = (bool)input.ShowedUp;
                }
                else
                {
                    entity.ShowedUp = !entity.ShowedUp;
                }

                if (eventEntity != null)
                {
                    eventEntity.UpdatedAt = DateTime.UtcNow;
                }

                await _databaseContext.SaveChangesAsync();
            }
        }

        public async Task<int> Count()
        {
            var result = await _databaseContext.Events.Where(e => e.Status == true).CountAsync();
            return result;
        }

        public async Task<List<EventDto>> List(ListInputDto input, PaginationInputDto? pagination, SortingInputDto? sorting)
        {
            var query = _databaseContext.Events.AsQueryable();

            query = query.Where(e => input.ShowUnmarked.HasValue ?
                input.ShowUnmarked.Value == true ?
                    true
                    :
                    e.Status == true
                :
                e.Status == true
            );

            query = query.Include(e => e.EventAttendants);

            if (input.ConsultorId != null)
            {
                query = query.Where(e => e.ConsultorId == input.ConsultorId);
            }

            if (input.ClientId != null)
            {
                query = query.Where(e => e.ClientId == input.ClientId);
            }

            if (input.OcurrenceMin != null)
            {
                query = query.Where(e => e.Ocurrence >= input.OcurrenceMin);
            }

            if (input.OcurrenceMax != null)
            {
                query = query.Where(e => e.Ocurrence <= input.OcurrenceMax);
            }

            if (input.Search != null)
            {
                query = query.Where(e =>
                    e.Title.ToLower().Trim().Contains(input.Search.ToLower().Trim()) ||
                    e.Description.ToLower().Trim().Contains(input.Search.ToLower().Trim()) ||
                    (e.Link ?? "").ToLower().Trim().Contains(input.Search.ToLower().Trim())
                );
            }

            if (sorting?.SortField != null)
            {
                switch (sorting?.SortField.ToLower().Trim())
                {
                    case "title":
                        if (sorting?.SortOrder != null && sorting.SortOrder.ToLower().Trim().Equals("desc"))
                            query = query.OrderByDescending(e => e.Title);
                        else
                            query = query.OrderBy(e => e.Title);
                        break;
                    case "ocurrence":
                        if (sorting?.SortOrder != null && sorting.SortOrder.ToLower().Trim().Equals("desc"))
                            query = query.OrderByDescending(e => e.Ocurrence);
                        else
                            query = query.OrderBy(e => e.Ocurrence);
                        break;
                    case "createdAt":
                        if (sorting?.SortOrder != null && sorting.SortOrder.ToLower().Trim().Equals("desc"))
                            query = query.OrderByDescending(e => e.CreatedAt);
                        else
                            query = query.OrderBy(e => e.CreatedAt);
                        break;
                    case "updatedAt":
                        if (sorting?.SortOrder != null && sorting.SortOrder.ToLower().Trim().Equals("desc"))
                            query = query.OrderByDescending(e => e.UpdatedAt);
                        else
                            query = query.OrderBy(e => e.UpdatedAt);
                        break;
                    default:
                        if (sorting?.SortOrder != null && sorting.SortOrder.ToLower().Trim().Equals("desc"))
                            query = query.OrderByDescending(e => e.CreatedAt);
                        else
                            query = query.OrderBy(e => e.CreatedAt);
                        break;
                }
            }
            else
            {
                query = query.OrderByDescending(x => x.CreatedAt);
            }

            if (pagination != null)
            {
                if (pagination?.Page != null && pagination.Page != 0 && pagination?.Limit != null && pagination.Limit != 0)
                {
                    var skip = ((pagination.Page - 1) * pagination.Limit) ?? 0;
                    var take = pagination.Limit ?? 10;

                    query = query.Skip(skip).Take(take);
                }
            }

            var result = query.Select(e => e.MapToDto());
            return await result.ToListAsync();
        }

        public async Task<float> GetShowedUpPercentages(ShowedUpPercentagesInputDto input)
        {
            var query = _databaseContext.Events.AsQueryable();
            query = query.Include(e => e.EventAttendants);

            if (input.ConsultorId.HasValue)
            {
                query = query.Where(e => e.ConsultorId == input.ConsultorId.Value);
            }

            var showedUpCount = await query
                .Join(
                    _databaseContext.EventAttendants,
                    e => e.Id,
                    a => a.EventId,
                    (e, a) => new
                    {
                        e.Ocurrence,
                        e.ConsultorId,
                        a.EventId,
                        a.ShowedUp
                    }
                )
                .Where(ep =>
                    ep.Ocurrence >= DateTimeOffset.UtcNow.AddMonths(
                        input.Months.HasValue ? (input.Months.Value * -1) : -1
                    ) &&
                    ep.Ocurrence <= DateTimeOffset.UtcNow &&
                    
                    ep.ShowedUp
                )
                .GroupBy(ep => ep.Ocurrence)
                .Select(g => new
                {
                    Ocurrence = g.Key,
                    QuantidadeParticipantes = g.Count()
                })
                .SumAsync(g => g.QuantidadeParticipantes);

            var totalCount = await query
                .Join(
                    _databaseContext.EventAttendants,
                    e => e.Id,
                    a => a.EventId,
                    (e, a) => new
                    {
                        e.Ocurrence,
                        a.EventId
                    }
                )
                .Where(ep =>
                    ep.Ocurrence >= DateTimeOffset.UtcNow.AddMonths(
                        input.Months.HasValue ? (input.Months.Value * -1) : -1
                    ) &&
                    ep.Ocurrence <= DateTimeOffset.UtcNow
                )
                .GroupBy(ep => ep.Ocurrence)
                .Select(g => new
                {
                    Ocurrence = g.Key,
                    QuantidadeParticipantes = g.Count()
                })
                .SumAsync(g => g.QuantidadeParticipantes);

            if (totalCount == 0)
                return 0;

            return (showedUpCount * 100) / totalCount;
        }

        public async Task<List<MarkedUnmarkedOutputDto>> GetMarkedUnmarked(MarkedUnmarkedInputDto input)
        {
            var query = _databaseContext.Events.AsQueryable();

            if (input.ConsultorId.HasValue)
            {
                query = query.Where(e => e.ConsultorId == input.ConsultorId.Value);
            }

            var result = await query
                .Where(e => e.Ocurrence >= DateTimeOffset.UtcNow.AddMonths(
                        input.Months.HasValue ? (input.Months.Value * -1) : -1
                    ) &&
                    e.Ocurrence <= DateTimeOffset.UtcNow
                )
                .GroupBy(e => new
                {
                    Year = e.Ocurrence.Year,
                    Month = e.Ocurrence.Month
                })
                .Select(g => new MarkedUnmarkedOutputDto()
                {
                    Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                    Marked = g.Count(e => e.Status),
                    Unmarked = g.Count(e => !e.Status)
                })
                .ToListAsync();

            return result;
        }

        public async Task<List<ShowedUpByClientOutputDto>> GetShowedUpByClient(ShowedUpByClientInputDto input)
        {
            var query = _databaseContext.Events.AsQueryable();
            query = query.Include(e => e.EventAttendants);

            if (input.ConsultorId.HasValue)
            {
                query = query.Where(e => e.ConsultorId == input.ConsultorId.Value);
            }

            var result = await query
                .Where(e => e.Ocurrence >= DateTimeOffset.UtcNow.AddMonths(
                        input.Months.HasValue ? (input.Months.Value * -1) : -1
                    ) &&
                    e.Ocurrence <= DateTimeOffset.UtcNow
                )
                .Join(
                    _databaseContext.EventAttendants,
                    e => e.Id,
                    ea => ea.EventId,
                    (e, ea) => new
                    {
                        Event = e,
                        EventAttendant = ea
                    }
                )
                .Where(ea => !ea.EventAttendant.ShowedUp)
                .GroupBy(e => e.Event.ClientId)
                .Select(g => new ShowedUpByClientOutputDto()
                {
                    EventCount = g.Count(),
                    ClientId = g.Key
                })
                .OrderByDescending(g => g.EventCount)
                .ToListAsync();

            return result;
        }

        public async Task<List<ShowedUpByAttendantOutputDto>> GetShowedUpByAttendant(ShowedUpByAttendantInputDto input)
        {
            var query = _databaseContext.Events.AsQueryable();
            query = query.Include(e => e.EventAttendants);

            var result = await query
                .Where(
                    e => e.ClientId == input.ClientId &&
                    e.Ocurrence >= DateTimeOffset.UtcNow.AddMonths(
                        input.Months.HasValue ? (input.Months.Value * -1) : -1
                    ) &&
                    e.Ocurrence <= DateTimeOffset.UtcNow
                )
                .Join(
                    _databaseContext.EventAttendants,
                    e => e.Id,
                    ea => ea.EventId,
                    (e, ea) => new
                    {
                        Event = e,
                        EventAttendant = ea
                    }
                )
                .Where(ea => !ea.EventAttendant.ShowedUp)
                .GroupBy(ea => ea.EventAttendant.AttendantId)
                .Select(g => new ShowedUpByAttendantOutputDto()
                {
                    EventCount = g.Count(),
                    AttendantId = g.Key
                })
                .OrderByDescending(g => g.EventCount)
                .ToListAsync();

            return result;
        }
    }
}
