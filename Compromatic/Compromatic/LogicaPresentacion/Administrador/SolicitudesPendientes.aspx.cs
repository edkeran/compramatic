using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_SolicitudesPendientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);

        if (Session["Sesion"] == null)
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
    }
   
  
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
        DAOadministrador conexion = new DAOadministrador();
        DataTable consulta = conexion.ArchivosEmpresa(id);
        Modal(consulta);
        //   Response.Redirect("MostrarArchivos.aspx");
    }

    protected void Modal(DataTable e)
    {
        if(e.Rows.Count <= 2){
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
            HyperLink2.NavigateUrl = e.Rows[1]["rutaArchivo"].ToString()+".pdf";
            HyperLink3.NavigateUrl = e.Rows[2]["rutaArchivo"].ToString()+".pdf";
        }
        
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="aceptar"){
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
            DAOadministrador conexion = new DAOadministrador();
            conexion.ModificarEstados(id, 1, 0, ((DataTable)(Session["sesion"])).Rows[0]["nomUsuario"].ToString());
            //Response.Redirect("SolicitudesPendientes.aspx");
            GridView1.DataBind();
            
        }
        if (e.CommandName == "rechazar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
            DAOadministrador conexion = new DAOadministrador();
            conexion.ModificarEstados(id, 0, 3, ((DataTable)(Session["sesion"])).Rows[0]["nomUsuario"].ToString());
            GridView1.DataBind();
            //Response.Redirect("SolicitudesPendientes.aspx");
        }
    }
}