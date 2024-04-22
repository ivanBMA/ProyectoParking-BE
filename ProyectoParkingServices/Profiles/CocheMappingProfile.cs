using AutoMapper;
using ProyectoParkingServices.Dto;

namespace ProyectoParkingServices.Profiles
{
    public class CocheMappingProfile : Profile
    {
        public CocheMappingProfile()
        {
            CreateMap<CocheDto, Coche>()
                .ReverseMap();
        }
    }
}
