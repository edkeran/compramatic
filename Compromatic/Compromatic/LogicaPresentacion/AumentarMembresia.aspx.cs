using System;
using System.Data;
using System.Web.UI;
using Logica;
using Utilitarios;

public partial class Presentacion_AumentarMembresia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_AumenMembre logi = new L_AumenMembre();
            U_AuxAumMemb resp = logi.page_load(IsPostBack, Session["Sesion"], Session["idEmpresa"]);
            TB_FechaInicio.Text = resp.TB_FechaInicio1;
            TB_FechaFinal.Text = resp.TB_FechaFinal1;
            TB_Precio.Text = resp.TB_Precio1;
            TB_Inicial.Text = resp.TB_Inicial1;
            TB_Final.Text = resp.TB_Final1;
            TB_Plan.Text = resp.TB_Plan1;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scr", "redireccionar('" + resp.Redirecion + "');", true);
        }catch(Exception er)
        {
            //NO HAGO NADA
        }
    }

    protected void DDL_Memebresia_SelectedIndexChanged(object sender, EventArgs e)
    {
        L_AumenMembre logi = new L_AumenMembre();
        DateTime Fecha = DateTime.Now.Date;
        DataTable Membresia=logi.ddl_membresia_event(DDL_Memebresia.SelectedValue);
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
        L_AumenMembre logi = new L_AumenMembre();
        Modal(logi.btn_comprar(Session["Sesion"], TB_FechaInicio.Text, TB_FechaFinal.Text, DDL_Memebresia.SelectedValue, Session["idEmpresa"]));
    }
}