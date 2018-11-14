using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Utilitarios;


namespace DatosPersistencia
{
    //Clase Para Validar El Token Rebido
    public class DB_Servicios
    {
        public bool validarEmpresaToken(string stToken, string nomEmpre)
        {
            using (var db= new Mapeo("servicios"))
            {
                var data = from serv in db.serv_Client
                           where serv.NomClient == nomEmpre && serv.Hash == stToken
                           select serv;
                if (data.Count() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
