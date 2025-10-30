using System;
using System.Collections.Generic;

namespace nomadate_web.Models;

public partial class ReservacionDetalle
{
    public int IdReservacionDetalle { get; set; }

    public int IdReservacion { get; set; }

    public DateOnly CheckIn { get; set; }

    public DateOnly CheckOut { get; set; }

    public decimal Precio { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Reservacion IdReservacionNavigation { get; set; } = null!;
}
