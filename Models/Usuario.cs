using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nomadate_web.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasenna { get; set; } = null!;

    public virtual ICollection<Resenna> Resennas { get; set; } = new List<Resenna>();

    public virtual ICollection<Reservacion> Reservacions { get; set; } = new List<Reservacion>();
}
