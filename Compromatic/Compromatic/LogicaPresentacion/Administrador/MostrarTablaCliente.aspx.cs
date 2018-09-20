using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_MostrarTabla : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_MostrarTablaCliente log = new L_MostrarTablaCliente();
        U_AuxQuejAdm res = log.pageLoad(Session["Sesion"], GridView1.Rows.Count, Session["sesion"], TableRowSection.TableHeader);
        GridView1.UseAccessibleHeader = res.AcceHeader;
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 35;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            //this.adm.InnerText = compIdioma["adm"].ToString();
     
        }
        catch (Exception ex)
        { }

        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + res.Redir + "');", true);
    }
}