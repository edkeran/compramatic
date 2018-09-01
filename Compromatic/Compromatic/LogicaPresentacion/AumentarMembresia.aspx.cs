using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_AumentarMembresia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

            DateTime Fecha = DateTime.Now.Date;
            TB_FechaInicio.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(1);
            TB_FechaFinal.Text = Fecha.ToShortDateString();
            DAOMembresia DAO_Membresia = new DAOMembresia();
            //AQUI HAY UN PROBLEMA CON EL TEMA DE LA MEMBRESIA
            DataTable Membresia = new DataTable();
            Membresia = DAO_Membresia.MostrarTipos(1);
            TB_Precio.Text = "$" + Membresia.Rows[0]["valorMembresia"].ToString() + " COP";
            //VERIFICAR FUNCION
            Membresia = DAO_Membresia.MostrarActual(int.Parse(Session["idEmpresa"].ToString()));
            TB_Inicial.Text = Membresia.Rows[0]["fechaInicio"].ToString();
            TB_Final.Text = Membresia.Rows[0]["fechaFin"].ToString();
            if (Membresia.Rows[0]["estadoMembresia"].ToString().Equals("1"))
            {
                TB_Plan.Text = "Activo";
            }
            else
            {
                TB_Plan.Text = "Vencida";
            }
        }
    }
    protected void DDL_Memebresia_SelectedIndexChanged(object sender, EventArgs e)
    {
        DAOMembresia DAO_Membresia = new DAOMembresia();
        DataTable Membresia = new DataTable();
        DateTime Fecha = DateTime.Now.Date;
        Membresia = DAO_Membresia.MostrarTipos(int.Parse(DDL_Memebresia.SelectedValue));
        TB_Precio.Text = "$" + Membresia.Rows[0]["valorMembresia"].ToString() + " COP";
        TB_FechaInicio.Text = Fecha.ToShortDateString();
        Fecha = Fecha.AddMonths(int.Parse(Membresia.Rows[0]["tiempoMembresia"].ToString()));
        TB_FechaFinal.Text = Fecha.ToShortDateString();
    }
    public void Modal(String mensaje)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }
    protected void BTN_Comprar_Click(object sender, EventArgs e)
    {
        DAOMembresia DAO_Membresia = new DAOMembresia();
        DataTable Membresia = new DataTable();
        Membresia = DAO_Membresia.MostrarActual(int.Parse(Session["idEmpresa"].ToString()));
        if(Membresia.Rows.Count>0)
        {
            Modal("Membresia Existente");
        }
        else
        {
            DataTable Empresa = (DataTable)Session["Sesion"];
            DAOEmpresa DAO_Empresa = new DAOEmpresa();
            DAO_Empresa.RegistrarMembresia(TB_FechaInicio.Text, TB_FechaFinal.Text, int.Parse(DDL_Memebresia.SelectedValue), int.Parse(Session["idEmpresa"].ToString()), Empresa.Rows[0]["nomEmpresa"].ToString());
            Modal("Membresia Registrada");
        }
    }
}