using Capa_Servicios;
using Capa_Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesarrolladoresController : ControllerBase
    {
        private readonly IUsuario _usuario;
        public DesarrolladoresController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpGet("Obtener-Desarrolladores")]
        public IActionResult getDesarrolladores()
        {
            return Ok(_usuario.ObtenerUsuarios());
        }
    }
}
