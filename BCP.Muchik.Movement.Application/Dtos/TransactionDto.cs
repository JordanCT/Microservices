namespace BCP.Muchik.Movement.Application.Dtos
{
    public class TransactionDto
    {
        public string Id { get; set; } = null!;
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
