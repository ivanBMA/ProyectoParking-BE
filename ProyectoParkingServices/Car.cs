using System;
using System.Collections.Generic;

namespace ProyectoParkingServices;

public partial class Car
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int ClientId { get; set; }
    public string Matricula { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;
}
