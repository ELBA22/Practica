using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Producto
{
    public string Cod { get; set; } = null!;

    public string NombreProd { get; set; }

    public int? Idmarca { get; set; }

    public virtual Marca IdmarcaNavigation { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
