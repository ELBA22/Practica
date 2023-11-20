using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Inventario
{
    public string Id { get; set; } = null!;

    public string? Nombre { get; set; }

    public double? Precio { get; set; }

    public short? Stock { get; set; }

    public short? StockMin { get; set; }

    public short? StockMax { get; set; }

    public string? CodProducto { get; set; }

    public int? Idpresentacion { get; set; }

    public virtual Producto? CodProductoNavigation { get; set; }

    public virtual ICollection<Detallemovinventario> Detallemovinventarios { get; set; } = new List<Detallemovinventario>();

    public virtual Presentacion? IdpresentacionNavigation { get; set; }
}
