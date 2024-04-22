using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoParkingServices.Dto;

namespace ProyectoParkingServices.Services
{
    public interface IFacturaService
    {
        List<FacturaDto> GetFacturas();
        FacturaDto GetFactura(int id);
        bool DeleteFactura(int id);
        FacturaDto StoreFactura(FacturaDto factura);
        FacturaDto PutFactura(int id, FacturaDto facturaDto);

    }
}
