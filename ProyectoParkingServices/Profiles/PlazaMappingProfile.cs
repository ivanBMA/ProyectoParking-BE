﻿using AutoMapper;
using ProyectoParkingServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Profiles
{
    public class PlazaMappingProfile : Profile
    {

        public PlazaMappingProfile()
        {
            CreateMap<PlazaDto, Plaza>().ReverseMap();
        }

    }
}

