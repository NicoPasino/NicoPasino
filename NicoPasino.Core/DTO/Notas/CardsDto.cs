using System.ComponentModel.DataAnnotations;

namespace NicoPasino.Core.DTO.Notas;

public partial class CardsDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El header es requerido.")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "El Titulo debe tener entre 1 y 50 caracteres.")]
    public string Header { get; set; }

    [Required(ErrorMessage = "El texto es requerido.")]
    [StringLength(5000, MinimumLength = 1, ErrorMessage = "El Texto debe tener entre 1 y 5000 caracteres.")]
    public string Text { get; set; }

    // El usuario no debe enviar fecha, solo recibir.
    public DateTime? FechaCreacion { get; set; } // (db) 2026-08-27 00:40:17 // String=> 27/8/2026 00:40:17 // DateTime=> 2026-08-27T00:40:17

    // El usuario no debe enviar fecha, solo recibir.
    public DateTime? FechaModificacion { get; set; }

    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    public string Name { get; set; }

    [StringLength(20, ErrorMessage = "El color no puede tener más de 20 caracteres.")]
    public string Color { get; set; }
}
