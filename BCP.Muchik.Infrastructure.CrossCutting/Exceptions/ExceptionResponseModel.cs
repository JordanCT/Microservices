namespace BCP.Muchik.Infrastructure.CrossCutting.Exceptions
{
    public class ExceptionResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = null!;
        public string StackTrace { get; set; } = null!;
    }
}
