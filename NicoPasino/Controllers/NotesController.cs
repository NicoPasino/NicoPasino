using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using NicoPasino.Core.DTO.Notas;
using NicoPasino.Core.Errores;
using NicoPasino.Core.Interfaces;

namespace NicoPasino.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableRateLimiting("general")]
    public class NotesController : Controller
    {
        private readonly INotasServicio _notasServicio;
        public NotesController(INotasServicio nServicio) {
            _notasServicio = nServicio;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() {
            try {
                var objs = await _notasServicio.GetAll(true);
                //await Task.Delay(3000); // 2000 ms = 2 segundos
                return Ok(objs);
            }
            catch (Exception ex) {
                return StatusCode(500, new { error = "Error desde el servidor." });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) {
            try {
                var obj = await _notasServicio.GetById(id);
                if (obj?.Id != null) return Ok(obj);
                else throw new NotFoundException("Nota no encontrada.");
            }
            catch (NotFoundException ex) {
                return NotFound(new { message = ex.Message }); // 404
            }
            catch (Exception ex) {
                return StatusCode(500, new { error = "Error desde el servidor." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CardsDto objeto) {
            try {
                if (objeto == null) throw new DataException("Datos inválidos, por favor revisar.");

                var ok = await _notasServicio.Create(objeto);
                if (ok) return StatusCode(202, "Elemento Creado"); // CreatedAtAction() 201 -> cambiar en frontend tmb
                else throw new Exception();
            }
            catch (DataException ex) {
                return BadRequest(new { message = ex.Message }); // 400
            }
            catch (Exception ex) {
                return StatusCode(500, new { error = "Error desde el servidor." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] CardsDto objeto) {
            try {
                if (objeto == null) throw new DataException("Datos inválidos, por favor revisar.");

                var ok = await _notasServicio.Update(objeto);
                if (ok) return StatusCode(202, "Elemento Actualizado");
                else throw new Exception();
            }
            catch (DataException ex) {
                return BadRequest(new { message = ex.Message }); // 400
            }
            catch (Exception ex) {
                return StatusCode(500, new { error = "Error desde el servidor." });
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ActualizarParcial(int id, [FromBody] CardsPatchDto objeto) {
            try {
                if (objeto == null) throw new DataException("Datos inválidos, por favor revisar.");

                var ok = await _notasServicio.UpdatePatch(id, objeto);
                if (ok) return StatusCode(202, "Elemento Actualizado");
                else throw new Exception();
            }
            catch (DataException ex) {
                return BadRequest(new { message = ex.Message }); // 400
            }
            catch (Exception ex) {
                return StatusCode(500, new { error = "Error desde el servidor." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id) {
            try {
                var res = await _notasServicio.Enable(id, false);
                if (res) return StatusCode(202, "Elemento Eliminado");
                else return new ObjectResult(new { message = "No se pudo eliminar." });
            }
            catch (DataException ex) {
                return BadRequest(new { message = ex.Message }); // 400
            }
            catch (Exception ex) {
                return StatusCode(500, new { error = "Error desde el servidor." });
            }
        }
    }
}
