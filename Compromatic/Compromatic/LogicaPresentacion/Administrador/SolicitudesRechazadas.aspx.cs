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
    /**
     * if (Session["Sesion"] == null)
        {
            Response.Redirect("LoginUsr.aspx");
        }
        else
        {

            int num = int.Parse(((DataTable)(Session["sesion"])).Rows[0]["idTipo"].ToString());
            if (int.Parse(((DataTable)(Session["sesion"])).Rows[0]["idTipo"].ToString()) == 1)
            { }
            else
            {
                Response.Redirect("LoginUsr.aspx");
            }
        }
     **/

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
        //DAOadministrador conexion = new DAOadministrador();
        DataTable consulta = logi.GV_1(id);
        Modal(consulta);
    }


    protected void Modal(DataTable e)
    {
        if (e.Rows.Count <= 2)
        {
            Titulo.Text = "No tiene documentos cargados";
            String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
            HyperLink1.Enabled = false;
            HyperLink2.Enabled = false;
            HyperLink3.Enabled = false;

        }
        else
        {
            String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
            HyperLink1.NavigateUrl = e.Rows[0]["rutaArchivo"].ToString()+".pdf";
            HyperLink2.NavigateUrl = e.Rows[1]["rutaArchivo"].ToString() + ".pdf";
            HyperLink3.NavigateUrl = e.Rows[2]["rutaArchivo"].ToString() + ".pdf";
        }
    }
}