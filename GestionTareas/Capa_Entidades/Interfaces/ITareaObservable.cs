using Capa_Datos.DTO;
using Capa_Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Interfaces
{
    public interface ITareaObservable
    {
        void Suscribir(UsuarioDTO usuario, Tarea tarea);
        void Desuscribir(UsuarioDTO observer, Tarea tarea);
        void Notificar(Tarea tarea, UsuarioDTO usuario);
    }
}
