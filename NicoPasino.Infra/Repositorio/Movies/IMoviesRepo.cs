using NicoPasino.Core.DTO.Movies;

namespace NicoPasino.Core.Repositorio.Movies
{
    public interface IMoviesRepo
    {
        Task<IEnumerable<MovieDto>> GetAll();
        Task<MovieDto> GetById(int id);
        Task<MovieDto> Create(MovieDto obj);
        Task<MovieDto> Delete(int id);
        Task<MovieDto> Update(MovieDto obj);
        Task<IEnumerable<string>> GetGenres();
    }
}
