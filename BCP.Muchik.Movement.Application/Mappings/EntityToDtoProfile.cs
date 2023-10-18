using AutoMapper;
using BCP.Muchik.Movement.Application.Dtos;
using BCP.Muchik.Movement.Domain.Entities;

namespace BCP.Muchik.Movement.Application.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
