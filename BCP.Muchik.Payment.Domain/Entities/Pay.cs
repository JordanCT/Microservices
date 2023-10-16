namespace BCP.Muchik.Payment.Domain.Entities
{
    public class Pay
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
