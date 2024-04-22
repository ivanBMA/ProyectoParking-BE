using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices
{
    public class Precios
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Precio { get; set; }
    }
}
