using AutoMapper;
using ProyectoParkingServices.Dto;

namespace ProyectoParkingServices.Profiles
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            CreateMap<CarDto, Car>()
                .ReverseMap();
        }
    }
}
