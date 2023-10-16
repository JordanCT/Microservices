namespace BCP.Muchik.Infrastructure.EventBus.Events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }

        protected Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
