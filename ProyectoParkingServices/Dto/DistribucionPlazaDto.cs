using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Dto
{
    public class DistribucionPlazaDto
    {
        public Int16 Id { get; set; }
        public Int16 Fila { get; set; }
        public Int16 Columna { get; set; }
        public bool EsPlaza { get; set; }
        public Int16 Id_Parking { get; set; }
    }
}
