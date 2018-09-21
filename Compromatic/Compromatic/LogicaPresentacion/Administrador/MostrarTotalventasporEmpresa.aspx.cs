using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_MostrarTotalventasporEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_MostrTablaEmp log = new L_MostrTablaEmp();

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 38;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.emp.InnerText = compIdioma["emp"].ToString();
            this.tot.InnerText = compIdioma["tot"].ToString();
            this.tot_ven.InnerHtml = compIdioma["tot_ven"].ToString() + " <small id='our_comp' runat='server'> " + compIdioma["our_comp"].ToString() + "</small>";
            this.vent.InnerText = compIdioma["vent"].ToString();
            this.LB_Ve_Tot.Text = compIdioma["LB_Ve_Tot"].ToString();
            this.LB_Wel.Text = compIdioma["LB_Wel"].ToString();
            this.GridView1.Columns[1].HeaderText = compIdioma["GV_Nit"].ToString();
            this.GridView1.Columns[2].HeaderText = compIdioma["GV_Nom"].ToString();
            this.GridView1.Columns[3].HeaderText = compIdioma["GV_Cal"].ToString();
            this.GridView1.Columns[4].HeaderText = compIdioma["GV_Val"].ToString();
            this.GridView1.Columns[5].HeaderText = compIdioma["GV_Tot"].ToString();
        }
        catch (Exception ex)
        { }


        U_AuxQuejAdm res = log.pageLoad(Session["Sesion"], Session["sesion"], GridView1.Rows.Count);
        GridView1.UseAccessibleHeader = true;
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + res.Redir + "');", true);

    }
}