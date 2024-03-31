using Application.Boundaries.Commom;
using Application.Chart.Boundaries.MarkedUnmarked;
using Application.Chart.Boundaries.ShowedUpByAttendant;
using Application.Chart.Boundaries.ShowedUpByClient;
using Application.Chart.Boundaries.ShowedUpPercentages;
using Application.Chart.Commands;
using Application.Chart.Handlers;
using Application.Event.Boundaries.Accept;
using Application.Event.Boundaries.Delete;
using Application.Event.Boundaries.DeleteByParams;
using Application.Event.Boundaries.List;
using Application.Event.Boundaries.New;
using Application.Event.Boundaries.ShowUp;
using Application.Event.Boundaries.Update;
using Application.Event.Commands;
using Application.Event.Handlers;
using Application.UseCase.Event;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using Domain.Repository;
using Infrastructure.Repository;
using MediatR;

namespace API.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddTransient<IRequestHandler<AcceptCommand, AcceptOutput>, AcceptHandler>();
            services.AddTransient<IRequestHandler<DeleteCommand, DeleteOutput>, DeleteHandler>();
            services.AddTransient<IRequestHandler<DeleteByParamsCommand, DeleteByParamsOutput>, DeleteByParamsHandler>();
            services.AddTransient<IRequestHandler<ListCommand, PaginatedResponse<ListOutput>>, ListHandler>();
            services.AddTransient<IRequestHandler<NewCommand, NewOutput>, NewHandler>();
            services.AddTransient<IRequestHandler<ShowUpCommand, ShowUpOutput>, ShowUpHandler>();
            services.AddTransient<IRequestHandler<UpdateCommand, UpdateOutput>, UpdateHandler>();

            services.AddTransient<IRequestHandler<ShowedUpPercentagesCommand, ShowedUpPercentagesOutput>, ShowedUpPercentagesHandler>();
            services.AddTransient<IRequestHandler<MarkedUnmarkedCommand, List<MarkedUnmarkedOutput>>, MarkedUnmarkedHandler>();
            services.AddTransient<IRequestHandler<ShowedUpByClientCommand, List<ShowedUpByClientOutput>>, ShowedUpByClientHandler>();
            services.AddTransient<IRequestHandler<ShowedUpByAttendantCommand, List<ShowedUpByAttendantOutput>>, ShowedUpByAttendantHandler>();

            services.AddScoped<IEventUseCase, EventUseCase>();

            services.AddScoped<IEventRepository, EventRepository>();
        }
    }
}
