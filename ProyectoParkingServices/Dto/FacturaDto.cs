using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Dto
{
    public class FacturaDto
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Coche { get; set; }
        public Int16 Id_Parking { get; set; }
        public int Id_Precio { get; set; }
        public Decimal Precio { get; set; }
        public int Tiempo { get; set; }
        public Decimal Importe { get; set; }
    }
}
