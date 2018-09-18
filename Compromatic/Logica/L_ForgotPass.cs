﻿using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using Datos;
using Utilitarios;

namespace Logica
{
    public class L_ForgotPass
    {
        public String pass(String Email)
        {
            DDAOUsuario db = new DDAOUsuario();
            if (db.ExistenciaCorreo(Email))
            {
                //Existe
                DataTable data = db.obtenerContrase(Email);
                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(Email));
                email.From = new MailAddress("compramatic@gmail.com");
                email.Subject = "Asunto ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.Body = "Su Contraseña Es: "+ data.Rows[0]["passUsuario"];
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