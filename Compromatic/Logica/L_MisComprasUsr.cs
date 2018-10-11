using System;
using System.Collections.Generic;
using System.Data;
using Datos;
using Utilitarios;
using DatosPersistencia;

namespace Logica
{
    public class L_MisComprasUsr
    {
        public U_aux_MisComprasUsr page_load(Object Session,bool postback)
        {
            DDAOUsuario user = new DDAOUsuario();
            U_aux_MisComprasUsr response = new U_aux_MisComprasUsr();
            if (!postback)
            {
                if (Session == null)
                {
                    //HAGO UN RETURN O UN BREAK;
                    response.Redireccion = "LoginUSr.aspx";
                    return response;
                    //Response.Redirect("LoginUSr.aspx");
                }
                DataTable datos = (DataTable)Session;
                if (int.Parse(datos.Rows[0]["idTipo"].ToString()) != 3)
                {
                    //HAGO UN RETURN O BREAK
                    response.Redireccion = "LoginUSr.aspx";
                    return response;
                    //Response.Redirect("LoginUsr.aspx");
                }
                DataTable datouser = (DataTable)Session;
                UEUsuario cliente = new UEUsuario();
                cliente.IdUsr = int.Parse(datouser.Rows[0]["idUsuario"].ToString());

                DBUsr daoUser = new DBUsr();
                DataTable peticiones = daoUser.historial_compras(cliente, 1);

                //DataTable peticiones = user.HistorialCompras(cliente, 1);
                DataTable aceptadas = daoUser.historial_compras(cliente, 2);
                DataTable rechazadas = daoUser.historial_compras(cliente, 3);
                DataTable hechas = daoUser.historial_compras(cliente, 4);

                response.Peticiones = peticiones;
                response.Aceptadas = aceptadas;
                response.Rechazadas = rechazadas;
                response.Hechas = hechas;
                //RETORNO EL RESPONSE
                return response;
            }
            else
            {
                //No  Hacer Nada
                throw new System.ArgumentException("No Cambiar Controles", "original");
            }
        }

       public U_aux_MisComprasUsr RP_PeticionesAceptadas_ItemCommand(String comand,String tb_2,Object session,String tb_1,String comandArg,String redirOrg)
        {
            //Funcion Para La Gestion De Las Peticiones Aceptadas
            U_aux_MisComprasUsr response = new U_aux_MisComprasUsr();
            if (comand.Equals("Confirmar"))
            {
                if (tb_2.Length == 0)
                {
                    response.Mensaje = "Antes de confirmar que recibiste el producto, es necesario que califiques a la empresa y des una breve opinión de tu experiencia de compra.";
                }
                else
                {
                    DDAOUsuario daousr = new DDAOUsuario();
                    DataTable user = (DataTable)session;
                    UEUsuario cliente = new UEUsuario();
                    cliente.IdUsr = int.Parse(user.Rows[0]["idUsuario"].ToString());
                    DataTable empresa = daousr.HistorialCompras(cliente, 2);

                    UEURango rango = new UEURango();
                    rango.IdUsr = cliente.IdUsr;
                    rango.IdEmp = int.Parse(empresa.Rows[0]["idEmpresa"].ToString());

                    rango.Rango = double.Parse(tb_1);
                    rango.Comentario = tb_2;
                    daousr.RegistrarRango(rango, user.Rows[0]["nomUsuario"].ToString());

                    DDAOadministrador calEmp = new DDAOadministrador();
                    empresa = calEmp.MostrarEmpresaId(rango.IdEmp);
                    double calAnt = double.Parse(empresa.Rows[0]["calificacionEmpresa"].ToString());
                    UEUEmpresa emp = new UEUEmpresa();
                    emp.Calificacion = (calAnt + rango.Rango) / 2;
                    emp.Id = rango.IdEmp;
                    daousr.CalificarEmp(emp, user.Rows[0]["nomUsuario"].ToString());

                    DDAOProducto confirmar = new DDAOProducto();
                    int venta = int.Parse(comandArg);
                    int estado = 4;
                    confirmar.ConfirmarRecibido(venta, estado, user.Rows[0]["nomUsuario"].ToString());
                    response.Mensaje = "Tu calificación ha sido enviada.";
                    response.Redireccion = "MisComprasUsr.aspx";

                    if (emp.Calificacion <= 3)
                    {
                        DDAOUsuario bl = new DDAOUsuario();
                        bl.CambiarEstadoEmp(emp.Id, 0, user.Rows[0]["nomUsuario"].ToString());
                    }
                }
            }
            return response;
        }

        public U_aux_MisComprasUsr Caso_nulos(U_aux_MisComprasUsr orig,U_aux_MisComprasUsr res)
        {
            if (res.Aceptadas == null)
            {
                res.Aceptadas = orig.Aceptadas;
            }
            if (res.Hechas == null)
            {
                res.Hechas = orig.Hechas;
            }
            if (res.Peticiones == null)
            {
                res.Peticiones = orig.Peticiones;
            }
            if (res.Rechazadas == null)
            {
                res.Rechazadas = orig.Rechazadas;
            }
            return res;
        }
    }
}
