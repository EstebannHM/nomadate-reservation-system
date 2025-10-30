using System;
using System.Collections.Generic;

namespace nomadate_web.Models;

public partial class Resenna
{
    public int IdResenna { get; set; }

    public int IdHabitacion { get; set; }

    public int IdUsuario { get; set; }

    public int Calificacion { get; set; }

    public string? Comentario { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Habitacion IdHabitacionNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
