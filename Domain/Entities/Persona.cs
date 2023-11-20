using System;
using System.Collections.Generic;


namespace Domain.Entities;

public partial class Persona
{
    public string Id { get; set; } = null!;

    public string Nombre { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public int? IdDocumento { get; set; }

    public int? IdRolPersona { get; set; }

    public int? IdTipoPersona { get; set; }

    public virtual ICollection<Contactopersona> Contactopersonas { get; set; } = new List<Contactopersona>();

    public virtual Tipodocumento IdDocumentoNavigation { get; set; }

    public virtual Rolpersona IdRolPersonaNavigation { get; set; }

    public virtual Tipopersona IdTipoPersonaNavigation { get; set; }

    public virtual ICollection<Movimientoinventario> MovimientoinventarioIdReceptorNavigations { get; set; } = new List<Movimientoinventario>();

    public virtual ICollection<Movimientoinventario> MovimientoinventarioIdResponsableNavigations { get; set; } = new List<Movimientoinventario>();
}
