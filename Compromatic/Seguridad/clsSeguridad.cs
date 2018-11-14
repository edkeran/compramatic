using System;
using System.Web;
using Logica;

namespace Seguridad
{
    public class clsSeguridad : System.Web.Services.Protocols.SoapHeader
    {
        //configurar la seguridad de momento con la cache

        //TOKEN ENVIADO PARA AUTENTICACION
        public string stToken { get; set; }
        //TOKEN GENERADO POR EL SERVER
        public string AutenticacionToken { get; set; }
        //Nom Empre
        public string nomEmp { get; set; }

        public bool blCredencialesValidas(string stToken,string nomEmp)
        {
            try
            {
                L_clsSeguridad logi = new L_clsSeguridad();
                if (logi.validarCredencialesAute(stToken,nomEmp))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Cambiar Por DB
        public bool blCredencialesValidas(clsSeguridad SoapHeader)
        {
            try
            {
                if (SoapHeader == null)
                {
                    return false;
                }
                if (!string.IsNullOrEmpty(SoapHeader.AutenticacionToken))
                {
                    return (HttpRuntime.Cache[SoapHeader.AutenticacionToken] != null);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
