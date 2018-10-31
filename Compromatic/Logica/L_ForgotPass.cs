using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
using DatosPersistencia;
using Utilitarios;
using Newtonsoft.Json;

namespace Logica
{
    public class L_ForgotPass
    {
        public String pass(String Email)
        {
            DBUsr daoUser = new DBUsr();
            //DDAOUsuario db = new DDAOUsuario();
            if (daoUser.ExistenciaCorreo(Email))
            {
                //Existe
                DataTable usr = daoUser.GET_USER(Email);
                String tok = JsonConvert.SerializeObject(usr);
                tok = tok + DateTime.Now;
                tok=Encriptar.GetMD5(tok);
                //DATOS A INSERTAR EN LA TABLA DE RECUPERAR CONTRASEÑA



                List<UEUsuario> data = daoUser.obtenerContrase(Email);
                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(Email));
                email.From = new MailAddress("compramatic@gmail.com");
                email.Subject = "Asunto ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.Body = "Su Contraseña Es: "+ data[0].PassUsr;
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("edgarkrejci12345@gmail.com", "ehtvlgoyrcxbgktc");
                try
                {
                    smtp.Send(email);
                    email.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
                return "Se Le Ha Enviado Un Email Con Su Contraseña";
            }
            else
            {
                //No Existe
                return "El Correo Ingresado No Existe";
            }
        }
    }
}
