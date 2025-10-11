using NicoPasino.Core.DTO.Movies;

namespace NicoPasino.Core.Repositorio.Movies
{
    public class MoviesRepo : IMoviesRepo
    {
        private readonly moviesdbContext _contexto;

        public MoviesRepo(moviesdbContext contexto) {
            _contexto = contexto;
        }

        public Task<MovieDto> Create(MovieDto obj) {
            throw new NotImplementedException();
        }

        public Task<MovieDto> Delete(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieDto>> GetAll() {
            throw new NotImplementedException();
        }

        public Task<MovieDto> GetById(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetGenres() {
            throw new NotImplementedException();
        }

        public Task<MovieDto> Update(MovieDto obj) {
            throw new NotImplementedException();
        }
    }
}
