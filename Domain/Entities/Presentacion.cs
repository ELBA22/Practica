using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Presentacion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
