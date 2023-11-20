using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Movimientoinventario
{
    public string Id { get; set; } = null!;

    public string? IdResponsable { get; set; }

    public string? IdReceptor { get; set; }

    public DateOnly? FechaMovimiento { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public int? IdtipoMovInv { get; set; }

    public int? IdFormaPago { get; set; }

    public virtual ICollection<Detallemovinventario> Detallemovinventarios { get; set; } = new List<Detallemovinventario>();

    public virtual Formapago? IdFormaPagoNavigation { get; set; }

    public virtual Persona? IdReceptorNavigation { get; set; }

    public virtual Persona? IdResponsableNavigation { get; set; }

    public virtual Tipomovinventario? IdtipoMovInvNavigation { get; set; }
}
