using DatosPersistencia;
using System.Data;
using Utilitarios;

namespace Logica
{
    public class L_ServicioCalificacion
    {
        public bool validar_existencia(string correoUser)
        {
            DBUsr daoUsuario = new DBUsr();
            int inf= daoUsuario.comprobar_correo(correoUser);
            if (inf == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void calificar_empresa(int id_Empresa,string nomUser,string correoUser,double rang)
        {
            DBUsr daoUsr = new DBUsr();
            UEUsuario client = daoUsr.get_usr_email(correoUser);

            UEURango rango = new UEURango();
            rango.IdUsr = client.IdUsr;
            rango.IdEmp = id_Empresa;
            rango.Rango = rang;
            rango.Comentario ="Calificacion Api";
            //Registramos el Rango en la Tabla De Los Rnagos
            daoUsr.RegistrarRango(rango, client.NomUsr);

            //Registramos este dato para la empresa Seleccionada
            DB_Admin daoAdministrador = new DB_Admin();
            DataTable empresa = daoAdministrador.MostrarEmpresaId(rango.IdEmp);
            double calAnt = double.Parse(empresa.Rows[0]["calificacionEmpresa"].ToString());
            UEUEmpresa emp = new UEUEmpresa();
            emp.Calificacion = (calAnt + rango.Rango) / 2;
            emp.Id = rango.IdEmp;
            daoUsr.CalificarEmp(emp, client.NomUsr);

        }

        public string insertar_Usuario(UEUsuario user)
        {
            L_Registro_Usr regi = new L_Registro_Usr();
            return regi.validaciones_Register(user.CorreoUsr,"12345678", "12345678",true, user);
        }
    }
}
