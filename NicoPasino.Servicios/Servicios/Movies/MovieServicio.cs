using NicoPasino.Core.DTO.Movies;
using NicoPasino.Core.Repositorio.Movies;

namespace NicoPasino.Servicios.Servicios.Movies
{
    public class MovieServicio : IMovieServicio
    {
        private readonly IMoviesRepo _repo;
        public MovieServicio(IMoviesRepo repo) {
            _repo = repo;
        }

        // Lógica de negocio (validaciones de datos)

        public Task<MovieDto> Create(MovieDto objeto) {
            var movieDto = _repo.Create(objeto);
            return movieDto;
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

        public Task<IEnumerable<MovieDto>> GetMovies() {
            var objeto = _repo.GetAll();

            return objeto;
        }

        public Task<MovieDto> Update(MovieDto obj) {
            throw new NotImplementedException();
        }
    }
}
