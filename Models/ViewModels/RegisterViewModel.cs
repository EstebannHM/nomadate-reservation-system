namespace nomadate_web.Models.ViewModels;

public class RegisterViewModel
{
    public string Nombre {get; set;} = null!;
    public string Apellido {get; set;} = null!;
    public string Email { get; set; } = null!;
    public string Contrasenna { get; set; } = null!;
    public string ConfirmarContrasenna { get; set; } = null!;
}