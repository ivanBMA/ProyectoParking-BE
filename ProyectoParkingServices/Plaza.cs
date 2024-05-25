using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices
{
    public class Plaza
    {
        public int Id { get; set; }
        //La base de datos es 0 o 1 no true o false por que no existe boolean
        public bool Ocupado { get; set; }
        public Int16 Id_Parking { get; set; }
        public Int16 Id_Distribucion { get; set; }

    }
}
