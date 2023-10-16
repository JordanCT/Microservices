using AutoMapper;
using BCP.Muchik.Payment.Application.Dtos;
using BCP.Muchik.Payment.Domain.Entities;

namespace BCP.Muchik.Payment.Application.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<PayDto, Pay>();
        }
    }
}
