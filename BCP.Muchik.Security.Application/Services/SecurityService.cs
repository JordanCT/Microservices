using AutoMapper;
using BCP.Muchik.Infrastructure.CrossCutting.BCrypt;
using BCP.Muchik.Infrastructure.CrossCutting.Exceptions;
using BCP.Muchik.Infrastructure.CrossCutting.Jwt;
using BCP.Muchik.Security.Application.Dtos;
using BCP.Muchik.Security.Application.Interfaces;
using BCP.Muchik.Security.Domain.Entities;
using BCP.Muchik.Security.Domain.Interfaces;

namespace BCP.Muchik.Security.Application.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IMapper _mapper;
        private readonly IJwtManager _jwtManager;
        private readonly IUserRepository _userRepository;

        public SecurityService(IMapper mapper, IJwtManager jwtManager, IUserRepository userRepository)
        {
            _mapper = mapper;
            _jwtManager = jwtManager;
            _userRepository = userRepository;
        }
        private User GetUserByUsername(string username)
        {
            var currentUser = _userRepository.Find(s => s.Username.Equals(username)).FirstOrDefault();
            return currentUser;
        }
        public SignInResponseDto SignIn(SignInRequestDto signInRequestDto)
        {
            var currentUser = GetUserByUsername(signInRequestDto.Username);
            if (currentUser == null || !BCryptManager.Verify(signInRequestDto.Password, currentUser.Password)) throw new BusinessException("Username or password incorrect.");
            var signInResponseDto = new SignInResponseDto();
            signInResponseDto.Token = _jwtManager.GenerateToken(currentUser.Id, currentUser.Username);
            return signInResponseDto;
        }

        public void SignUp(UserDto userDto)
        {
            var currentUser = GetUserByUsername(userDto.Username);
            if (currentUser is not null)
            {
                throw new BusinessException("User alredy exists.");
            }

            var user = _mapper.Map<User>(userDto);
            user.Password = BCryptManager.HashText(user.Password);
            _userRepository.Add(user);
            _userRepository.Save();
        }
    }
}
