using NicoPasino.Core.DTO.Movies;

namespace NicoPasino.Servicios.Servicios.Movies
{
    public interface IMovieServicio
    {
        Task<IEnumerable<MovieDto>> GetAll();
        Task<MovieDto> Create(MovieDto obj);
        Task<MovieDto> GetById(int id);
        Task<MovieDto> Delete(int id);
        Task<MovieDto> Update(MovieDto obj);
        Task<IEnumerable<string>> GetGenres();
    }
}
