using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_VerProducto : System.Web.UI.Page
{
    //METODO DE LA PAGINA CUANDO CARGA
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_verProducto logica = new L_verProducto();
            UEUProducto resp = logica.page_load(IsPostBack, Session["VerProducto"], Session["Sesion"]);
            LB_NombreProducto.Text = resp.Nombre;
            LB_DescripcionProducto.Text = resp.Descripcion;
            LB_PrecioProducto.Text = resp.PrecioString;
            LB_NombreEmpresa.Text = resp.NomEmp;
            LB_CantidadProducto.Text = resp.Cantidad.ToString();
            LB_CategoriaProducto.Text = resp.NomCategoria;
            RP_FotosProductos.DataSource = resp.Fotos;
            RP_FotosProductos.DataBind();
        }
        catch(Exception ex)
        {}
    }

    public void Modal(String mensaje)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }


    protected void BTN_ComprarProducto_Click(object sender, EventArgs e)
    {
        L_verProducto logic = new L_verProducto();
        UAuxVenta response=logic.BTN_ComprarProducto_Click(Session["Sesion"], Session["VerProducto"], TB_CantidadVenta.Text, LB_CantidadProducto.Text);
        Modal(response.Msg);
        BTN_Modal.Visible = response.Valido;
        BTN_Yes.Visible = response.BtnYes;
    }

    protected void BTN_Reportar_Click(object sender, EventArgs e)
    {
        L_verProducto logica = new L_verProducto();
        UAuxVenta resp= logica.BTN_Reportar_Click(Session["Sesion"], Session["VerProducto"], DDL_Reportes.SelectedValue);
        Modal(resp.Msg);
        BTN_Modal.Visible = resp.Valido;
    }

    
    protected void BTN_Modal_Click(object sender, EventArgs e)
    {
        Response.Redirect("LoginUsr.aspx");
    }

    protected void BTN_Yes_Click(object sender, EventArgs e)
    {
        L_verProducto logica = new L_verProducto();
        logica.BTN_Yes_Click(Session["Sesion"], Session["VerProducto"], TB_CantidadVenta.Text);
        Response.Redirect("MisComprasUsr.aspx");
    }
    
}
 