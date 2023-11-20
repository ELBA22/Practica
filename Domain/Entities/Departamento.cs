using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Departamento
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public int? IdpaisFk { get; set; }
}
