using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Interfaces
{
    public interface IAutentication
    {
        bool RegistrarUsuario(Usuario usuario);
        bool LoguearUsuario(Usuario usuario);
    }
}
