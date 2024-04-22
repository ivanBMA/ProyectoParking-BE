using System;
using System.Collections.Generic;

namespace ProyectoParkingServices;

public partial class Cliente
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Nif { get; set; }

    public virtual ICollection<Coche> Cars { get; set; } = new List<Coche>();
}
