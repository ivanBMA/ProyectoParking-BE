using AutoMapper;
using ProyectoParkingServices.Dto;

namespace ProyectoParkingServices.Profiles
{
    public class FacturaMappingProfile : Profile
    {
        public FacturaMappingProfile()
        {
            CreateMap<FacturaDto, Factura>()
                .ReverseMap();
        }
    }
}
