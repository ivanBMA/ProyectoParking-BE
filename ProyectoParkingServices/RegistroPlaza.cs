using System;
using System.Collections.Generic;

namespace ProyectoParkingServices
{
    public partial class RegistroPlaza
    {
        public int Id { get; set; }
        public int Id_Plaza { get; set; }
        public int Id_Coche { get; set; }
        public int Id_Parking {  get; set; }
        public Boolean tipoEvento { get; set; }
        public DateTime fechaEvento {get; set;}
        

    }
}
