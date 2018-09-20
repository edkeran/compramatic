using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
using System.Collections;

public partial class Presentacion_SolicitudesPendientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_SolicitudesPendientes logi = new L_SolicitudesPendientes();
        String respo = logi.page_load(Session["Sesion"], Session["sesion"]);

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 32;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.soli.InnerText = compIdioma["soli"].ToString();
            this.pend.InnerText = compIdioma["pend"].ToString();
            this.sol_pen.InnerHtml = compIdioma["sol_pen"].ToString() + "<small id='new_opt' runat='server'> " + compIdioma["new_opt"].ToString() + "</small>";
        }
        catch (Exception ex)
        { }

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

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 32;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            GridView gv = (GridView)sender;
            ((Button)e.Row.FindControl("Button1")).Text = compIdioma["Button1"].ToString();
            ((Label)e.Row.FindControl("Label3")).Text = compIdioma["Label3"].ToString();
            ((Label)e.Row.FindControl("Label4")).Text = compIdioma["Label4"].ToString();
            ((Label)e.Row.FindControl("Label7")).Text = compIdioma["Label7"].ToString();
            ((Label)e.Row.FindControl("LB_Parr")).Text = compIdioma["LB_Parr"].ToString();
            ((Label)e.Row.FindControl("corre")).Text = compIdioma["corre"].ToString();
            ((Button)e.Row.FindControl("BT_Aceptar")).Text = compIdioma["BT_Aceptar"].ToString();
            ((Button)e.Row.FindControl("BT_Rechazar")).Text = compIdioma["BT_Rechazar"].ToString();
            //this.respo.InnerText
        }
        catch (Exception ex)
        { }
    }
}