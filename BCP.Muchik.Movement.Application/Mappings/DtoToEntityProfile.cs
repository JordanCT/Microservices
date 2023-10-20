using AutoMapper;
using BCP.Muchik.Movement.Application.Dtos;
using BCP.Muchik.Movement.Domain.Entities;

namespace BCP.Muchik.Movement.Application.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<RegisterTransactionDto, Transaction>();
        }
    }
}
