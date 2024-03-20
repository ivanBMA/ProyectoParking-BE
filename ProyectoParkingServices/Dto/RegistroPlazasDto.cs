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
        public TimeOnly horaEntrada { get; set; }
        public TimeOnly horaSalida { get; set; }
        public DateOnly fecha { get; set; }
        public double precio { get; set; }
    }
}
