using ProyectoParkingServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Services
{
    public interface IRegistroPlazaService
    {
        public List<RegistroPlazasDto> GetRegistroPlazas();
        public RegistroPlazasDto StoreRegistroPlaza(RegistroPlazasDto registroDto);
        public RegistroPlazasDto GetRegistroPlaza(int id);
        public bool DeleteRegistroPlazas(int id);

    }
}
