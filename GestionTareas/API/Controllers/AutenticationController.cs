using Capa_Entidades;
using Capa_Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticationController : ControllerBase
    {
        private readonly IAutentication _autenticar;

        public AutenticationController(IAutentication autenticar)
        {
            _autenticar = autenticar;
        }

        [HttpPost("Registro")]

        public IActionResult RegistrarUsuario([FromBody] Usuario usuario)
        {
            _autenticar.RegistrarUsuario(usuario);
            return Ok("Usuario registrado con exito");
        }

        [HttpPost("Login")]
        public IActionResult Logout([FromBody] Usuario usuario)
        {
           var user = _autenticar.LoguearUsuario(usuario);
            if (user == true)
            {
                return Ok("Usuario logueado");

            }
            else
            {
                return BadRequest("Correo o contrasena incorrecta");
            }

        }
    }
}
