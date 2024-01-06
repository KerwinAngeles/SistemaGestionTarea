using Capa_Datos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string assignarDeveloper { get; set; }
        public bool seguirTarea { get; set; } = false;
        public List<UsuarioDTO> Observadores { get; set;}

    }
}
