using BCP.Muchik.Infrastructure.EventBus.Interfaces;
using BCP.Muchik.Movement.Application.Dtos;
using BCP.Muchik.Movement.Application.Events;
using BCP.Muchik.Movement.Application.Interfaces;

namespace BCP.Muchik.Movement.Application.EventHandlers
{
    public class TransactionConfirmEventHandler : IEventHandler<TransactionConfirmEvent>
    {
        private readonly IMovementService _movementService;

        public TransactionConfirmEventHandler(IMovementService movementService)
        {
            _movementService = movementService;
        }

        public Task Handle(TransactionConfirmEvent @event)
        {
            var transaction = new RegisterTransactionDto
            {
                InvoiceId = @event.InvoiceId,
                Amount = @event.Amount,
                Date = @event.CreatedAt
            };
            _movementService.RegisterTransactionAsync(transaction);
            return Task.CompletedTask;
        }
    }
}
