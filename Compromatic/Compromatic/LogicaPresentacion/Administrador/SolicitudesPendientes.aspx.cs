using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class Presentacion_SolicitudesPendientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_SolicitudesPendientes logi = new L_SolicitudesPendientes();
        String respo = logi.page_load(Session["Sesion"], Session["sesion"]);
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

    /*  protected void BT_Aceptar_Click(object sender, EventArgs e)
      {
       //   GridViewRow row = GridView1.SelectedDataKey;
       //   int id =Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
          DAOUsuario conexion = new DAOUsuario();
          conexion.ModificarEstados(10,1,0);
         // Response.Redirect("SolicitudesPendientes.aspx");

      }
      protected void BT_Rechazar_Click(object sender, EventArgs e)
      {
          GridViewRow row = GridView1.SelectedRow;
          int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
          DAOUsuario conexion = new DAOUsuario();
          conexion.ModificarEstados(id, 0, 0);
      }*/
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
        L_SolicitudesPendientes conexion = new L_SolicitudesPendientes();
        DataTable consulta = conexion.GV_1(id);
        Modal(consulta);
        //   Response.Redirect("MostrarArchivos.aspx");
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            GridViewRow row = GridView1.Rows[index];
            int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
            L_SolicitudesPendientes logica = new L_SolicitudesPendientes();
            logica.GV1_RowCommand(e.CommandName, id, e.CommandArgument.ToString(), Session["sesion"]);
            GridView1.DataBind();
        }catch(Exception er)
        {

        }
    }
}