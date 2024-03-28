using Application.Event.Boundaries.DeleteByParams;
using Application.Event.Commands;
using Application.UseCase.Event;
using Domain.Base.Communication.Mediator;
using Domain.Base.Messages.Common.Notification;
using Domain.Dto.Event;
using MediatR;

namespace Application.Event.Handlers
{
    public class DeleteByParamsHandler : IRequestHandler<DeleteByParamsCommand, DeleteByParamsOutput>
    {
        public IMediatorHandler _mediatorHandler;
        public IEventUseCase _eventUseCase;

        public DeleteByParamsHandler(IMediatorHandler mediatorHandler, IEventUseCase eventUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _eventUseCase = eventUseCase;
        }

        public async Task<DeleteByParamsOutput> Handle(DeleteByParamsCommand command, CancellationToken cancellationToken)
        {
            if (command.IsValid())
            {
                var input = command.Input;

                var deleteByParamsInput = new DeleteByParamsInputDto()
                {
                    ClientId = input.ClientId
                };

                var deletedAny = await _eventUseCase.DeleteByParams(deleteByParamsInput);

                if (deletedAny == false)
                {
                    var message = "Nenhum evento foi deletado";
                    await _mediatorHandler.PublishNotification(new DomainNotification(command.MessageType, message));
                    return default;
                }

                return default;
            }

            foreach (var error in command.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(command.MessageType, error.ErrorMessage));
            }

            return default;
        }
    }
}
