﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoParkingServices.Dto;

namespace ProyectoParkingServices.Services
{
    public interface IDistribucionPlazaService
    {
        List<DistribucionPlazaDto> GetDistribucionPlazas();
        DistribucionPlazaDto GetDistribucionPlaza(int id);
        bool DeleteDistribucionPlaza(int id);
        DistribucionPlazaDto StoreDistribucionPlaza(DistribucionPlazaDto distribucionPlaza);
        DistribucionPlazaDto PutDistribucionPlaza(int id, DistribucionPlazaDto distribucionPlazaDto);
        List<DistribucionPlazaDto> GetDistribucionPlazasByParking(Int16 id);
        public bool rellenarDistribucion(Archivo? archivo);

    }
}
