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
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 36;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.clien.InnerText = compIdioma["clien"].ToString();
            this.clien2.InnerText = compIdioma["clien"].ToString();
            this.see_all.InnerText = compIdioma["see_all"].ToString();
            this.usr_clien.InnerHtml = compIdioma["usr_clien"].ToString()+" <small id='our_comp' runat='server'>" + compIdioma["our_comp"].ToString() + "</small>";
            this.LB_parr.Text = compIdioma["LB_parr"].ToString();
            this.LB_Wel.Text = compIdioma["LB_Wel"].ToString();
            this.GridView1.Columns[0].HeaderText = compIdioma["GV_Nom"].ToString();
            this.GridView1.Columns[1].HeaderText = compIdioma["GV_Apel"].ToString();
            this.GridView1.Columns[2].HeaderText = compIdioma["GV_Tel"].ToString();
            this.GridView1.Columns[3].HeaderText = compIdioma["GV_Corr"].ToString();
            this.GridView1.Columns[4].HeaderText = compIdioma["GV_Cc"].ToString();
            this.GridView1.Columns[5].HeaderText = compIdioma["GV_Dir"].ToString();
            this.GridView1.Columns[6].HeaderText = compIdioma["GV_Cal"].ToString();
            this.GridView1.Columns[7].HeaderText = compIdioma["GV_Crea"].ToString();
                
        }
        catch (Exception ex)
        { }
        U_AuxQuejAdm res = log.pageLoad(Session["Sesion"], GridView1.Rows.Count, Session["sesion"], TableRowSection.TableHeader);
        GridView1.UseAccessibleHeader = res.AcceHeader;
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + res.Redir + "');", true);
    }
}