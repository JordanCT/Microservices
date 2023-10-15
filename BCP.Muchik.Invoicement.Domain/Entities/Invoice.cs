namespace BCP.Muchik.Invoicement.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int State { get; set; }
    }
}
