namespace BCP.Muchik.Infrastructure.CrossCutting.Jwt
{
    public interface IJwtManager
    {
        string GenerateToken(int userId, string username);
    }
}
