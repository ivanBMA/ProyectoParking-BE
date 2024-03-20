using ProyectoParkingServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Services
{
    public interface IRegistroPlazasServices
    {
        public List<RegistroPlazasDto> GetRegistroPlazas();
        public RegistroPlazasDto StoreRegistroPlaza(RegistroPlazasDto registroDto);
    }
}
