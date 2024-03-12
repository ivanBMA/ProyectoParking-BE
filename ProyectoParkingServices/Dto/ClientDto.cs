using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoParkingServices.Dto
{
    internal class ClientDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Nif { get; set; }

    }
}
