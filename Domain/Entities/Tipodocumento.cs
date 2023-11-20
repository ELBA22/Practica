using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Tipodocumento
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
