using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoParkingServices.Dto;

namespace ProyectoParkingServices.Services
{
    public interface IPreciosService
    {
        List<PreciosDto> GetPrecios();
        PreciosDto GetPrecio(int id);
         PreciosDto StorePrecio(PreciosDto precioDto);
         bool DeletePrecio(int id);

    }
}
