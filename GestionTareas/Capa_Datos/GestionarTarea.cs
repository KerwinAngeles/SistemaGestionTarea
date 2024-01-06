using Capa_Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capa_Datos
{
    public class GestionarTarea
    {
        public string Ruta { get; set; }

        public GestionarTarea()
        {
            Ruta = @"C:\Proyectos\ArqCapas\ProyectoGestionTareas\GestionTareas\Capa_Datos\wwwroot\Task.txt";
        }

        public void SerializarJsonFile(List<Tarea> tareas)
        {
            var tarea = JsonConvert.SerializeObject(tareas, Formatting.Indented);
            File.WriteAllText(Ruta, tarea);
        }

        public List<Tarea> DeserealizarTarea()
        {
            if (File.Exists(Ruta))
            {
                try
                {
                    string json = File.ReadAllText(Ruta);
                    List<Tarea> tareas = JsonConvert.DeserializeObject<List<Tarea>>(json);
                    return tareas;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new List<Tarea>();
        }
    }
}
