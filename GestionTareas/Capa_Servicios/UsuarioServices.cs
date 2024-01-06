using Capa_Datos;
using Capa_Datos.DTO;
using Capa_Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios
{
    public class UsuarioServices : IUsuario
    {
        private readonly GestionarUsuario _gestion;
        public UsuarioServices(GestionarUsuario gestion)
        {
            _gestion = gestion;
        }

        public List<UsuarioDTO> ObtenerUsuarios()
        {
            var listaUsuario = new List<UsuarioDTO>();
            var data = _gestion.DeserealizarUsuario();

            foreach (var item in data)
            {
                UsuarioDTO user = new UsuarioDTO();
                user.Id = item.Id;
                user.Nombre = item.Nombre;
                user.Correo = item.Correo;

                listaUsuario.Add(user);
            }

            return listaUsuario;    
        }
    }
}
