using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProyectoParkingServices.Dto;

namespace ProyectoParkingServices.Services
{
    public interface IPlazasService
    {
        public List<PlazaDto> GetPlazas();
        public PlazaDto StorePlaza(PlazaDto plaza);
        public PlazaDto GetPlaza(int id);
        public bool DeletePlaza(int id);
        public PlazaDto PutPlaza(int id, PlazaDto plazaDto);
        List<PlazaDto> GetByParkingID(Int16 id);

    }
}
