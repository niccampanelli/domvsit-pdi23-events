using Domain.Dto.Commom;
using Domain.Dto.Event;
using Domain.Mappers.Event;
using Domain.Repository;
using Infrastructure.Setup;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<int> Count()
        {
            var result = await _databaseContext.Events.CountAsync();
            return result;
        }

        public async Task<List<EventDto>> List(ListInputDto input, PaginationInputDto? pagination, SortingInputDto? sorting)
        {
            var query = _databaseContext.Events.AsQueryable();
            query = query.Include(e => e.EventAttendants);

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

            if (input.ConsultorId != null)
            {
                query = query.Where(e => e.ConsultorId == input.ConsultorId);
            }

            if (input.ClientId != null)
            {
                query = query.Where(e => e.ClientId == input.ClientId);
            }

            var result = query.Select(e => e.MapToDto());
            return await result.ToListAsync();
        }
    }
}
