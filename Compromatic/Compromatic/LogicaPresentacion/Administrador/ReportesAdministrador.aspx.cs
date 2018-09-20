using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_ReportesAdministrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_ReporteAdmin logi = new L_ReporteAdmin();
        String res = logi.page_load(Session["Sesion"],Session["sesion"]);

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 30;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.pro_rep2.InnerHtml= compIdioma["pro_rep"].ToString()+ "<small id='n_opt' runat='server'> "+compIdioma["n_opt"].ToString()+"</small>";
            this.reporte.InnerText = compIdioma["reporte"].ToString();
            this.pro_rep.InnerText = compIdioma["pro_rep"].ToString();

            //this.sol.InnerText = compIdioma["sol"].ToString();
            //this.respo.InnerText
        }
        catch (Exception ex)
        { }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scr", "redireccionar('" + res + "');", true);
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
        idProducto.Text = id.ToString();
        Modal();
        //   Response.Redirect("MostrarArchivos.aspx");
    }
    protected void Modal()
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
    }

    protected void TablaImagenes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DataTable Fotos = new DataTable();
        L_ReporteAdmin logi = new L_ReporteAdmin();
        //IADProducto IAD_Producto = new IADProducto();
        Fotos = logi.images(int.Parse(idProducto.Text));
        String ruta = Fotos.Rows[e.Item.ItemIndex]["rutaArchivo"].ToString();
        ruta = (Server.MapPath("~\\Archivos\\FotosProductos") + "\\" + ruta);
        String name = ((DataTable)Session["sesion"]).Rows[0]["nomUsuario"].ToString();
        logi.Delete_image(int.Parse(e.CommandArgument.ToString()),name);
        try
        {
            System.IO.File.Delete(ruta);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        Response.Redirect(Request.Url.AbsoluteUri);
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 30;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            GridView gv = (GridView)sender;
            ((Label)e.Row.FindControl("Label3")).Text = compIdioma["Label3"].ToString();
            ((Label)e.Row.FindControl("Label4")).Text = compIdioma["Label4"].ToString();
            ((Label)e.Row.FindControl("Label7")).Text = compIdioma["Label7"].ToString();
            ((Label)e.Row.FindControl("LB_Parr")).Text = compIdioma["LB_Parr"].ToString();
            ((Button)e.Row.FindControl("Button1")).Text = compIdioma["Button1"].ToString();
            ((Label)e.Row.FindControl("LB_Corr")).Text = compIdioma["LB_Corr"].ToString();
            ((Label)e.Row.FindControl("LB_Date")).Text = compIdioma["LB_Date"].ToString();
            //this.respo.InnerText
        }
        catch (Exception ex)
        { }
    }
}