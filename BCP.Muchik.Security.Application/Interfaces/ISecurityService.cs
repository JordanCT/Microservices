using BCP.Muchik.Security.Application.Dtos;

namespace BCP.Muchik.Security.Application.Interfaces
{
    public interface ISecurityService
    {
        void SignUp(CreateUserDto userDto);
        SignInResponseDto SignIn(SignInRequestDto signInRequestDto);
    }
}
