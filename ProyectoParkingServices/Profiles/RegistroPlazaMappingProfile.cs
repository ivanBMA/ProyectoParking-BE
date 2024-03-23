using AutoMapper;
using ProyectoParkingServices.Dto;
using ProyectoParkingServices.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Profiles
{
    public class RegistroPlazaMappingProfile : Profile
    {
        public RegistroPlazaMappingProfile()
        {
            CreateMap<RegistroPlaza, RegistroPlazasDto>().ReverseMap();
        }
    }
}
