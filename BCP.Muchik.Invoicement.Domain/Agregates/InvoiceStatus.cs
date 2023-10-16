namespace BCP.Muchik.Invoicement.Domain.Agregates
{
    public class InvoiceStatus
    {
        public static InvoiceStatus Pending = new InvoiceStatus(1, nameof(Pending).ToLowerInvariant());
        public static InvoiceStatus Paid = new InvoiceStatus(2, nameof(Paid).ToLowerInvariant());
        public int Id { get; private set; }
        public string Name { get; private set; }
        public InvoiceStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
