using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_SolicitudesRechazadas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_SolicitudesRechazadas logi = new L_SolicitudesRechazadas();
        String respo= logi.page_load(Session["Sesion"],Session["sesion"]);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scrt", "redireccionar('" + respo + "');", true);
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //
        // Se obtiene la fila seleccionada del gridview
        //
        GridViewRow row = GridView1.SelectedRow;
        //
        // Obtengo el id de la entidad que se esta editando
        // en este caso de la entidad Person
        //
        int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
        L_SolicitudesRechazadas logi = new L_SolicitudesRechazadas();
        DataTable consulta = logi.GV_1(id);
        Modal(consulta);
    }


    protected void Modal(DataTable e)
    {
        L_SolicitudesRechazadas logica = new L_SolicitudesRechazadas();
        U_Aux_SoliciRechaza res = logica.L_Modal(e.Rows.Count, e);
        Titulo.Text = res.Respo[0];
        HyperLink1.NavigateUrl = res.Respo[1];
        HyperLink2.NavigateUrl = res.Respo[2];
        HyperLink3.NavigateUrl = res.Respo[3];
        HyperLink1.Enabled = res.Enables[0];
        HyperLink2.Enabled = res.Enables[1];
        HyperLink3.Enabled = res.Enables[2];
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
    }
}