using System;
using System.Data;
using Utilitarios;
using Datos;
using DatosPersistencia;

namespace Logica
{
    public class L_PeticionesCompra
    {
        public U_aux_PeticionesCompra page_load(bool postback,Object Session)
        {
            DBEmpresa daoEmpresa = new DBEmpresa();
            //DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            U_aux_PeticionesCompra response = new U_aux_PeticionesCompra();
            if (!postback)
            {
                if (Session == null)
                {
                    response.Redireccion = "LoginUsr.aspx";
                    return response;
                    //Response.Redirect("LoginUsr.aspx");
                }
                DataTable Empresa = (DataTable)Session;
                if (Empresa.Rows[0]["idTipo"].ToString() != "2")
                {
                    response.Redireccion = "LoginUsr.aspx";
                    return response;
                    //Response.Redirect("LoginUsr.aspx");
                }
                if (int.Parse(Empresa.Rows[0]["estadoEmpresa"].ToString()) != 1)
                {
                    response.Redireccion = "PerfilEmpresa.aspx";
                    return response;
                    //Response.Redirect("PerfilEmpresa.aspx");
                }
                DataTable Productos = daoEmpresa.PeticionesCompra(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
                response.Producto = Productos;
                DataTable productos2 = new DataTable();
                productos2 = daoEmpresa.PeticionesEnProceso(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
                response.Producto2 = productos2;
                DataTable productos3 = new DataTable();
                productos3 = daoEmpresa.PeticionesFinalizadas(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
                response.Producto3 = productos3;
                DataTable productos4 = new DataTable();
                productos4 = daoEmpresa.PeticionesHechas(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
                response.Producto4 = productos4;
                response.Redireccion = "0";
                return response;
            }
            else
            {
                throw new System.ArgumentException("Valido");
            }
        }

        public void validarExcep(String msg)
        {
            if (!msg.Equals("Valido"))
            {
                throw new System.ArgumentException("msg");
            }
        }

        public String RP_Peticiones_ItemCommand(Object Session,String CommandArgument,String CommandName)
        {
            int resultado;
            DBEmpresa daoEmpresa = new DBEmpresa();
            DataTable Empresa = (DataTable)Session;
            //DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            if (CommandName.Equals("Aceptar"))
            {
                resultado = daoEmpresa.AprobarVenta(int.Parse(CommandArgument), Empresa.Rows[0]["nomEmpresa"].ToString());
                if (resultado == 1)
                {
                    return "Inventario Insuficiente,0";
                    //Modal("Inventario Insuficiente");
                }
                else
                {
                    return "Transaccion Exitosa,PeticionesCompra.aspx";
                    //Modal("Transaccion Exitosa");
                    //Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
            if (CommandName.Equals("Declinar"))
            {
                daoEmpresa.RechazarVenta(int.Parse(CommandArgument), Empresa.Rows[0]["nomEmpresa"].ToString());
                return "4,PeticionesCompra.aspx";
                //Response.Redirect(Request.Url.AbsoluteUri);
            }
            return "0,0";
        }

        public String enProceso_ItemCommand(String CommandName,String CommandArgument,DataTable Empresa)
        {
            String respo;
            if (CommandName.Equals("Cancelar"))
            {
                DBEmpresa daoEmpresa = new DBEmpresa();
                //DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
                daoEmpresa.RechazarVenta(int.Parse(CommandArgument.ToString()), Empresa.Rows[0]["nomEmpresa"].ToString());
                //Response.Redirect(Request.Url.AbsoluteUri);
                respo = "PeticionesCompra.aspx";
                return respo;
            }
            respo = "0";
            return respo;
        }

        public DataTable RP_VentasReali(String CommandArgument)
        {
            DBEmpresa daoEmpresa = new DBEmpresa();
            //DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            return daoEmpresa.PeticionCompra(int.Parse(CommandArgument.ToString()));
        }

        public void btn_Calificar(DataTable Empresa,String TB_Calificacion,String TB_Comentario,String LB_Usuario,String LB_Venta)
        {
            DBEmpresa daoEmpresa = new DBEmpresa();
            //DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            daoEmpresa.CalificarCliente(Double.Parse(TB_Calificacion), TB_Comentario, int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()), int.Parse(LB_Usuario), int.Parse(LB_Venta), Empresa.Rows[0]["nomEmpresa"].ToString());
        }
    }
}
