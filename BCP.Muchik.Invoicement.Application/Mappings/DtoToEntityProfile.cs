using AutoMapper;
using BCP.Muchik.Invoicement.Application.Dtos;
using BCP.Muchik.Invoicement.Domain.Entities;

namespace BCP.Muchik.Invoicement.Application.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<CreateInvoiceDto, Invoice>();
        }
    }
}
