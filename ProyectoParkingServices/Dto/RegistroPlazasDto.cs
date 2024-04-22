using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Dto
{
    public class RegistroPlazasDto 
    {
        public int Id { get; set; }
        public int Id_Plaza { get; set; }
        public int Id_Coche { get; set; }
        public int Id_Parking { get; set; }
        public Boolean tipoEvento { get; set; }
        public DateTime fechaEvento { get; set; }
    }
}
