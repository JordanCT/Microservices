namespace BCP.Muchik.Movement.Domain.Entities
{
    public class Transaction
    {
        public string Id { get; set; } = null!;
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
