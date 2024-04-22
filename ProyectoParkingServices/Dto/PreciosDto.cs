using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Dto
{
    public class PreciosDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Precio { get; set; }
    }
}
