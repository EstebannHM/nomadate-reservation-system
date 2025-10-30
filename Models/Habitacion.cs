using System;
using System.Collections.Generic;

namespace nomadate_web.Models;

public partial class Habitacion
{
    public int IdHabitacion { get; set; }

    public string NumeroHabitacion { get; set; } = null!;

    public int Capacidad { get; set; }

    public decimal Precio { get; set; }

    public string? Descripcion { get; set; }

    public bool TieneAire { get; set; }

    public bool TieneTv { get; set; }

    public string? RutaImagen { get; set; }

    public virtual ICollection<Resenna> Resennas { get; set; } = new List<Resenna>();

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();
}
