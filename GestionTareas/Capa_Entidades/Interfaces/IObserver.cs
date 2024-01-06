using Capa_Datos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public interface IObserver
    {
        void Actualizar(Tarea tarea, UsuarioDTO usuario);
    }
}
