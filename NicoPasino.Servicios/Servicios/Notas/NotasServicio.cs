using Mapster;
using NicoPasino.Core.DTO.Notas;
using NicoPasino.Core.Errores;
using NicoPasino.Core.Interfaces;
using NicoPasino.Core.Modelos.Notas;

namespace NicoPasino.Servicios.Servicios.Notas
{
    public class NotasServicio : INotasServicio
    {
        private readonly IRepositorioGenerico<Cards> _repoG;
        public NotasServicio(IRepositorioGenerico<Cards> repoG) {
            _repoG = repoG ?? throw new ArgumentNullException(nameof(repoG));
        }

        public async Task<IEnumerable<CardsDto>> GetAll(bool activo) {
            //return Enumerable.Empty<CardsDto>();
            try {
                var objsDb = await _repoG.ListarAsync(
                    orden: q => q.OrderByDescending(m => m.FechaModificacion)
                );

                if (objsDb != null && objsDb.Any()) {
                    var objsDto = objsDb.Adapt<IEnumerable<CardsDto>>();
                    return objsDto;
                }
                return Enumerable.Empty<CardsDto>();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CardsDto> GetById(int id) {
            if (id <= 0) throw new NotFoundException("Id de la Nota no válida.");
            var objDb = await _repoG.GetAsync(
                filtro: item => item.IdPublica == id // id -> IdPublica
            );

            if (objDb != null) {
                var objDto = objDb.Adapt<CardsDto>();
                return objDto;
            }
            else throw new NotFoundException("Nota no encontrada.");
        }

        public async Task<bool> Create(CardsDto obj) {
            Random random = new Random();
            if (obj == null) throw new DataException("No se recibió ningún dato.");
            if (ValidateObj(obj)) throw new DataException("Titulo y/o Texto vacíos.");

            var objeto = obj.Adapt<Cards>();
            objeto.Id = 0;
            objeto.IdPublica = random.Next(1, 9999999);
            objeto.FechaCreacion = DateTime.UtcNow;
            objeto.FechaModificacion = DateTime.UtcNow;

            var res = await _repoG.Add(objeto);

            return (res != null);
        }


        public async Task<bool> Update(CardsDto obj) {
            if (obj == null) throw new DataException("No se recibió ningún dato.");
            if (ValidateObj(obj)) throw new DataException("Titulo y/o Texto vacíos.");

            var objDb = await _repoG.GetAsync(filtro: x => x.IdPublica == obj.Id);
            if (objDb == null) throw new DataException("Nota original no encontrada en la base de datos.");

            var objeto = obj.Adapt<Cards>();

            objeto.Id = objDb.Id;
            objeto.IdPublica = obj.Id;
            objeto.FechaModificacion = DateTime.UtcNow;
            objeto.FechaCreacion = objDb.FechaCreacion;
            objeto.Archivado = objDb.Archivado;
            objeto.Eliminado = objDb.Eliminado;

            Cards objetoRdy = objeto.Adapt<Cards>();

            var res = await _repoG.Update(objetoRdy);

            if (res > 0) return true;
            else throw new UpdateException("No se pudo actualizar la Nota en la base de datos.");
        }

        public async Task<bool> UpdatePatch(int id, CardsPatchDto obj) {
            if (obj == null) throw new DataException("No se recibió ningún dato.");

            var objDb = await _repoG.GetAsync(filtro: x => x.IdPublica == id);
            if (objDb == null) throw new DataException("Nota original no encontrada en la base de datos.");

            if (!string.IsNullOrWhiteSpace(obj.Header)) objDb.Header = obj.Header;
            if (!string.IsNullOrWhiteSpace(obj.Text)) objDb.Text = obj.Text;
            if (!string.IsNullOrWhiteSpace(obj.Name)) objDb.Name = obj.Name;
            if (!string.IsNullOrWhiteSpace(obj.Color)) objDb.Color = obj.Color;
            if (obj.Favorito.HasValue) objDb.Favorito = obj.Favorito.Value;
            if (obj.Archivado.HasValue) objDb.Archivado = obj.Archivado.Value;
            if (obj.Eliminado.HasValue) objDb.Eliminado = obj.Eliminado.Value;

            objDb.FechaModificacion = DateTime.UtcNow;

            var res = await _repoG.Update(objDb);

            if (res > 0) return true;
            else throw new UpdateException("No se pudo actualizar la Nota en la base de datos.");
        }

        public async Task<bool> Enable(int id, bool estado) {
            var objDb = await _repoG.GetAsync(filtro: x => x.IdPublica == id);
            if (objDb == null) throw new DataException("Nota original no encontrada en la base de datos.");
            else {
                await _repoG.Delete(objDb);
                return true;
            }
        }

        public Task<IEnumerable<CardsDto>> GetAll(string campo, string? valor) {
            throw new NotImplementedException();
        }

        public bool ValidateObj(CardsDto card) {
            if (string.IsNullOrWhiteSpace(card.Header)) return true;
            if (string.IsNullOrWhiteSpace(card.Text)) return true;
            return false;
        }
    }
}