using System;
using System.Collections.Generic;

namespace nomadate_web.Models;

public partial class Reservacion
{
    public int IdReservacion { get; set; }

    public int IdHabitacion { get; set; }

    public int IdUsuario { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Habitacion IdHabitacionNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<ReservacionDetalle> ReservacionDetalles { get; set; } = new List<ReservacionDetalle>();
}
