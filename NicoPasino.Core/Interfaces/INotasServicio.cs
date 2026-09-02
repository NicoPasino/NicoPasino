using NicoPasino.Core.DTO.Notas;
using NicoPasino.Core.Modelos.Notas;

namespace NicoPasino.Core.Interfaces
{
    public interface INotasServicio : IServicioGenerico<Cards, CardsDto>
    {
        Task<bool> UpdatePatch(int id, CardsPatchDto obj);
    }
}
