using System.ComponentModel.DataAnnotations;

namespace NicoPasino.Core.DTO.Notas;

public partial class CardsPatchDto
{
    [StringLength(50, MinimumLength = 1, ErrorMessage = "El Titulo debe tener entre 1 y 50 caracteres.")]
    public string? Header { get; set; }

    [StringLength(5000, MinimumLength = 1, ErrorMessage = "El Texto debe tener entre 1 y 5000 caracteres.")]
    public string? Text { get; set; }

    public DateTime? FechaModificacion { get; set; }

    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    public string? Name { get; set; }

    [StringLength(20, ErrorMessage = "El color no puede tener más de 20 caracteres.")]
    public string? Color { get; set; }

    public bool? Favorito { get; set; }

    public bool? Archivado { get; set; }

    public bool? Eliminado { get; set; }
}
