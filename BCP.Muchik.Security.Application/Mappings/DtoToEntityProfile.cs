using AutoMapper;
using BCP.Muchik.Security.Application.Dtos;
using BCP.Muchik.Security.Domain.Entities;

namespace BCP.Muchik.Security.Application.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
