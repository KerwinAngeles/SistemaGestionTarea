using Capa_Datos;
using Capa_Datos.DTO;
using Capa_Entidades;
using Capa_Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios
{
    public class AutenticationServices : IAutentication
    {
        private readonly GestionarUsuario _gestUsuario;

        public AutenticationServices(GestionarUsuario _usuario)
        {
            _gestUsuario = _usuario;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            List<Usuario> registro = _gestUsuario.DeserealizarUsuario();
            if(registro.Any(r => r.Correo == usuario.Correo))
            {
                Console.WriteLine("El usuario ya exite");
                return false;
            }
            else
            {
                var user = new Usuario
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Correo = usuario.Correo,
                    Contrasena = usuario.Contrasena,
                    Rol = usuario.Rol,
                };

                registro.Add(user);

                _gestUsuario.SerializarJsonFile(registro);
                return true;
            }
        }

        public bool LoguearUsuario(Usuario usuarios)
        {
            List<Usuario> loguear = _gestUsuario.DeserealizarUsuario();

            var usuario = loguear.FirstOrDefault(u => u.Correo == usuarios.Correo && u.Contrasena == usuarios.Contrasena && u.Rol == usuarios.Rol);

            if(usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
