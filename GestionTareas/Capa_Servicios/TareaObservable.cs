using Capa_Datos;
using Capa_Datos.DTO;
using Capa_Entidades;
using Capa_Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Capa_Servicios
{
    public class TareaObservable : ITareaObservable
    {
        private List<UsuarioDTO> Observadores = new List<UsuarioDTO>();
        private List<Tarea> tareas = new List<Tarea>();
        private GestionarTarea gestionarTarea = new GestionarTarea();

        public TareaObservable() 
        {
            tareas = gestionarTarea.DeserealizarTarea();
        }

        public void Suscribir(UsuarioDTO observer, Tarea tarea)
        {
            if (!Observadores.Contains(observer))
            {
                Observadores.Add(observer);
            }

            if (!tarea.Observadores.Any(o => o.Correo == observer.Correo))
            {
                tarea.Observadores.Add(observer);
                tarea.seguirTarea = true;
                gestionarTarea.SerializarJsonFile(tareas);
            }

        }

        public void Desuscribir(UsuarioDTO observer , Tarea tarea)
        {
            if (Observadores.Contains(observer))
            {
                Observadores.Remove(observer);
            }

            foreach (var observador in tarea.Observadores.ToList())
            {
                if (observador.Correo == observer.Correo)
                {
                    tarea.Observadores.Remove(observador);
                    gestionarTarea.SerializarJsonFile(tareas);
                }
            }

        }

        public void Notificar(Tarea tarea, UsuarioDTO usuario)
        {
            foreach (var obs in tarea.Observadores)
            {
                obs.Actualizar(tarea, usuario);
            }
        }

        public void CrearTarea(Tarea tarea)
        {
            var existe = tareas.Any(t => t.Id == tarea.Id);
            if (!existe)
            {
                tareas.Add(tarea);

                gestionarTarea.SerializarJsonFile(tareas);
            }
        }

        public void EditarTarea(Tarea tarea)
        {
            Tarea ActualizandoTarea = tareas.Find(n => n.Id == tarea.Id);
            if (ActualizandoTarea != null)
            {
                ActualizandoTarea.Titulo = tarea.Titulo;
                ActualizandoTarea.Descripcion = tarea.Descripcion;
                gestionarTarea.SerializarJsonFile(tareas);
            }
        }
        public void EliminarTarea(int idTarea)
        {
            Tarea eliminarTarea = tareas.Find(t => t.Id == idTarea);
            if(eliminarTarea != null)
            {
                tareas.Remove(eliminarTarea);
                gestionarTarea.SerializarJsonFile(tareas);
            }
        }

        public Tarea BuscarTarea(int idTarea)
        {
            var BuscarTarea = tareas.Find(b => b.Id == idTarea);
            return BuscarTarea;
        }

        public List<Tarea> TareasCreadas()
        {
            return tareas;
        }

        public void AsignarTarea(Tarea tarea, UsuarioDTO usuario)
        {
            tarea = tareas.Find(t => t.Id == tarea.Id);
            if (tarea != null)
            {
                if(tarea.seguirTarea)
                {
                    UsuarioDTO usuarioExistente = tarea.Observadores.FirstOrDefault(u => u.Correo == usuario.Correo);

                    if (usuarioExistente != null)
                    {
                        tarea.assignarDeveloper = usuarioExistente.Correo;
                        Notificar(tarea, usuarioExistente);
                    }

                }
                else
                {
                    tarea.seguirTarea= false;
                }
            }   
        }    
    }
}
