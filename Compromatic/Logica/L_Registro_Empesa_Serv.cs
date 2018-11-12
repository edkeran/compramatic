using Utilitarios;
using DatosPersistencia;

namespace Logica
{
    public class L_Registro_Empesa_Serv
    {
        public string registrar_Empresa (UEUEmpresa emp)
        {
            try
            {
                DBEmpresa daoEmpr = new DBEmpresa();
                daoEmpr.InsertarEmpresa(emp);
                return "Registro Satisfactorio";
            }
            catch (System.Exception ex)
            {

                return "Hay Ocurrido Un Error Inesperado" + ex.Message;
            }
           
            
        }
    }
}
