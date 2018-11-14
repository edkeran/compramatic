using DatosPersistencia;
namespace Logica
{
    public class L_clsSeguridad
    {
        public bool validarCredencialesAute(string token,string empr)
        {
            DB_Servicios daoServ = new DB_Servicios();
            return daoServ.validarEmpresaToken(token, empr);
        }
    }
}
