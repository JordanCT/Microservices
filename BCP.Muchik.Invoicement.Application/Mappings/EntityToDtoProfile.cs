using AutoMapper;
using BCP.Muchik.Invoicement.Application.Dtos;
using BCP.Muchik.Invoicement.Domain.Entities;

namespace BCP.Muchik.Invoicement.Application.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
        }
    }
}
