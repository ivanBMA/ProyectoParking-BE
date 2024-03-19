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
        public List<Plaza> GetPlazas();
        public Plaza StorePlaza(Plaza plaza);
        public Plaza GetPlaza(int id);
        public bool DeleteCar(int id);
        public Plaza PutPlaza(int id, Plaza plazaDto);

    }
}
