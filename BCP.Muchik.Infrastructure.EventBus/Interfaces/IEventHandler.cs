using BCP.Muchik.Infrastructure.EventBus.Events;

namespace BCP.Muchik.Infrastructure.EventBus.Interfaces
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler { }
}
