using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_PeticionesCompra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DAOEmpresa DAO_Empresa = new DAOEmpresa();
        if (!IsPostBack)
        {

            if (Session["Sesion"] == null)
            {
                Response.Redirect("LoginUsr.aspx");
            }
            DataTable Empresa = (DataTable)Session["Sesion"];
            if (Empresa.Rows[0]["idTipo"].ToString() != "2")
            {
                Response.Redirect("LoginUsr.aspx");
            }
            if (int.Parse(Empresa.Rows[0]["estadoEmpresa"].ToString()) != 1)
            {
                Response.Redirect("PerfilEmpresa.aspx");
            }

            DataTable Productos = DAO_Empresa.PeticionesCompra(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
            RP_Peticiones.DataSource = Productos;
            RP_Peticiones.DataBind();
            Productos = DAO_Empresa.PeticionesEnProceso(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
            RP_EnProceso.DataSource = Productos;
            RP_EnProceso.DataBind();
            Productos = DAO_Empresa.PeticionesFinalizadas(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
            RP_VentasRealizadas.DataSource = Productos;
            RP_VentasRealizadas.DataBind();
            Productos = DAO_Empresa.PeticionesHechas(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
            RP_Finalizadas.DataSource = Productos;
            RP_Finalizadas.DataBind();
        }
    }
    protected void RP_Peticiones_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int resultado;
        DataTable Empresa = (DataTable)Session["Sesion"];
        DAOEmpresa DAO_Empresa= new DAOEmpresa();
        if(e.CommandName.Equals("Aceptar"))
        {
           resultado= DAO_Empresa.AprobarVenta(int.Parse(e.CommandArgument.ToString()),Empresa.Rows[0]["nomEmpresa"].ToString());
            if(resultado==1)
            {
                Modal("Inventario Insuficiente");
            }else
            {
                 Modal("Transaccion Exitosa");
                 Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
        if (e.CommandName.Equals("Declinar"))
        {
            DAO_Empresa.RechazarVenta(int.Parse(e.CommandArgument.ToString()),Empresa.Rows[0]["nomEmpresa"].ToString());
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }

    public void Modal(String mensaje)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }
    protected void RP_EnProceso_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        if (e.CommandName.Equals("Cancelar"))
        {
            DAOEmpresa DAO_Empresa = new DAOEmpresa();
            DAO_Empresa.RechazarVenta(int.Parse(e.CommandArgument.ToString()),Empresa.Rows[0]["nomEmpresa"].ToString());
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
    protected void RP_VentasRealizadas_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DAOEmpresa DAO_Empresa = new DAOEmpresa();
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-calificar').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        DataTable Venta = DAO_Empresa.PeticionCompra(int.Parse(e.CommandArgument.ToString()));
        LB_Usuario.Text = Venta.Rows[0]["idUsuario"].ToString();
        LB_Venta.Text = e.CommandArgument.ToString();
    }
    protected void BTN_Calificar_Click(object sender, EventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        DAOEmpresa DAO_Empresa = new DAOEmpresa();
        DAO_Empresa.CalificarCliente(Double.Parse(TB_Calificacion.Text),TB_Comentario.Text,int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()),int.Parse(LB_Usuario.Text),int.Parse(LB_Venta.Text),Empresa.Rows[0]["nomEmpresa"].ToString());
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}