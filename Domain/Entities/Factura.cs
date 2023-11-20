using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Factura
{
    public int Id { get; set; }

    public int? FacturaInicial { get; set; }

    public int? FacturaFinal { get; set; }

    public int? FacturaActual { get; set; }

    public string? NroResolucion { get; set; }
}
