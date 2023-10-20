namespace BCP.Muchik.Movement.Application.Dtos
{
    public class RegisterTransactionDto
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
