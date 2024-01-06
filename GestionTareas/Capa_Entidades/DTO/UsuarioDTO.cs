using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.DTO
{
    public class UsuarioDTO : IObserver
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        public void Actualizar(Tarea tarea, UsuarioDTO usuario)
        {
              
            string mensaje = "error al enviar el correo electronico";
            try
            {
                 MailMessage email = new MailMessage();
                 email.From = new MailAddress("pruebadeprogramacion12@gmail.com");
                 email.To.Add(usuario.Correo);
                 email.Subject = tarea.Titulo;
                 email.Body = tarea.Descripcion;
                 email.IsBodyHtml = true;

                 SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                 smtp.UseDefaultCredentials = false;
                 smtp.Credentials = new NetworkCredential("pruebadeprogramacion12@gmail.com", "usvb wkjz gtzv bree");
                 smtp.EnableSsl = true;
                 smtp.Send(email);
                 mensaje = "Mensaje enviado con exito";

            }
            catch (Exception ex)
            {
                 mensaje = "Error al enviar el correo: " + ex.ToString();

            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            UsuarioDTO otroUsuario = (UsuarioDTO)obj;
            return Correo == otroUsuario.Correo;
        }
    }
}
