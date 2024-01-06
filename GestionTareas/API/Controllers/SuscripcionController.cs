using Capa_Datos.DTO;
using Capa_Entidades;
using Capa_Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuscripcionController : ControllerBase
    {
        private readonly TareaObservable _tareaObservable;
        
        public SuscripcionController(TareaObservable tareaObservable)
        {
            _tareaObservable = tareaObservable;
        }

        [HttpPost("AsignarTarea")]
        public IActionResult Asignar([FromBody] UsuarioDTO usuario)
        {
            var tarea = _tareaObservable.BuscarTarea(usuario.Id);

            if (tarea.seguirTarea == true)
            {
                _tareaObservable.AsignarTarea(tarea, usuario);
                return Ok($"Tarea asignada al desarrollador {usuario.Correo}");
            }
            else
            {
                return Ok($"Debes seguir la tarea para que se le sea asignada");

            }
        }

        [HttpPost("Seguir-Tarea")]
        public IActionResult SeguirTarea([FromBody] UsuarioDTO usuario)
        {
            var tarea = _tareaObservable.BuscarTarea(usuario.Id);

            if (tarea == null)
                return NotFound();

            _tareaObservable.Suscribir(usuario, tarea);

            return Ok($"{usuario.Correo} ha comenzado a seguir la tarea {usuario.Id}");
        }

        [HttpPost("Dejar-Tarea")]
        public IActionResult DejarTarea([FromBody] UsuarioDTO usuario)
        {
            var tarea = _tareaObservable.BuscarTarea(usuario.Id);

            if (tarea == null)
                return NotFound();

            _tareaObservable.Desuscribir(usuario, tarea);
            return Ok("Desuscrito");
        }
    }
}
