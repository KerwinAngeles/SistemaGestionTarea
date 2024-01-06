using Capa_Datos.DTO;
using Capa_Entidades;
using Capa_Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly TareaObservable _tareaObservable;

        public TareaController(TareaObservable tareaObservable)
        {
            _tareaObservable = tareaObservable;
        }

        [HttpPost("Crear-Tarea")]
        public IActionResult CrearTarea([FromBody] Tarea tarea)
        {
            _tareaObservable.CrearTarea(tarea);
            return Ok("Tarea creada");
        }

        [HttpPut("Editar-Tarea")]
        public IActionResult EditarTarea([FromBody] Tarea tarea)
        {
            _tareaObservable.EditarTarea(tarea);
            return Ok("Tarea Editada");
        }

        [HttpDelete("Eliminar-Tarea")]
        public IActionResult EliminarTarea(int id)
        {
            _tareaObservable.EliminarTarea(id);
            return Ok("Tarea eliminada");
        }

        [HttpGet("Buscar-Tarea")]
        public IActionResult BuscarTarea(int id)
        {
            var tarea = _tareaObservable.BuscarTarea(id);
            return Ok(tarea);
        }

        [HttpGet("Tareas-Creadas")]
        public ActionResult<List<Tarea>> TareasCreadas()
        {
            var tareas = _tareaObservable.TareasCreadas();
            return Ok(tareas);  
        }

    }
}
