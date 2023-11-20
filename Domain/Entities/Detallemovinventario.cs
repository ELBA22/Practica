using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Detallemovinventario
{
    public string IdInventario { get; set; } = null!;

    public string IdMovInv { get; set; } = null!;

    public sbyte? Cantidad { get; set; }

    public double? Precio { get; set; }

    public virtual Inventario IdInventarioNavigation { get; set; } = null!;

    public virtual Movimientoinventario IdMovInvNavigation { get; set; } = null!;
}
