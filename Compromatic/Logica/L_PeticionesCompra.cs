using System;
using System.Data;
using Utilitarios;
using Datos;

namespace Logica
{
    public class L_PeticionesCompra
    {
        public U_aux_PeticionesCompra page_load(bool postback,Object Session)
        {
            DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
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
                DataTable Productos = DAO_Empresa.PeticionesCompra(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
                response.Producto = Productos;
                //RP_Peticiones.DataSource = Productos;
                //RP_Peticiones.DataBind();
                DataTable productos2 = new DataTable();
                productos2 = DAO_Empresa.PeticionesEnProceso(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
                response.Producto2 = productos2;
                //RP_EnProceso.DataSource = Productos;
                //RP_EnProceso.DataBind();
                DataTable productos3 = new DataTable();
                productos3 = DAO_Empresa.PeticionesFinalizadas(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
                response.Producto3 = productos3;
                //RP_VentasRealizadas.DataSource = Productos;
                //RP_VentasRealizadas.DataBind();
                DataTable productos4 = new DataTable();
                productos4 = DAO_Empresa.PeticionesHechas(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
                response.Producto4 = productos4;
                //RP_Finalizadas.DataSource = Productos;
                //RP_Finalizadas.DataBind();
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
            DataTable Empresa = (DataTable)Session;
            DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            if (CommandName.Equals("Aceptar"))
            {
                resultado = DAO_Empresa.AprobarVenta(int.Parse(CommandArgument), Empresa.Rows[0]["nomEmpresa"].ToString());
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
                DAO_Empresa.RechazarVenta(int.Parse(CommandArgument), Empresa.Rows[0]["nomEmpresa"].ToString());
                return "4,PeticionesCompra.aspx";
                //Response.Redirect(Request.Url.AbsoluteUri);
            }
            return "0,0";
        }
    }
}
