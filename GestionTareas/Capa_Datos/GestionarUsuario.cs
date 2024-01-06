using Capa_Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace Capa_Datos
{
    public class GestionarUsuario
    {
        public string Ruta { get; set; }

        public GestionarUsuario()
        {
            Ruta = @"C:\Proyectos\ArqCapas\ProyectoGestionTareas\GestionTareas\Capa_Datos\Usuario.json";
        }

        public void SerializarJsonFile(List<Usuario> user)
        {
            var usuario = JsonConvert.SerializeObject(user.ToArray(), Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Ruta, usuario);
        }

        public List<Usuario> DeserealizarUsuario()
        {
            if (File.Exists(Ruta))
            {
                try
                {
                    string json = File.ReadAllText(Ruta);
                    List<Usuario> usuariosRegistrado = JsonConvert.DeserializeObject<List<Usuario>>(json);
                    return usuariosRegistrado;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return new List<Usuario>();
        }
    }
}
