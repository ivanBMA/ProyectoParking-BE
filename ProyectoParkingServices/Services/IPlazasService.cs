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
    }
}
