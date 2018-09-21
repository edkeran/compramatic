using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
using System.Collections;

public partial class Presentacion_MostrarTablaEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_MostrTablaEmp log = new L_MostrTablaEmp();

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 37;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.emp.InnerText = compIdioma["emp"].ToString();
            this.all.InnerText = compIdioma["all"].ToString();
            this.usr_emp.InnerHtml = compIdioma["usr_emp"].ToString() + " <small id='our_com' runat='server'> " + compIdioma["our_com"].ToString() + "</small>";
            this.empres.InnerText = compIdioma["empres"].ToString();
            this.LB_Emp_Reg.Text = compIdioma["LB_Emp_Reg"].ToString();
            this.LB_Wel.Text = compIdioma["LB_Wel"].ToString();
            this.GridView1.Columns[0].HeaderText = compIdioma["GV_Nom"].ToString();
            this.GridView1.Columns[1].HeaderText = compIdioma["GV_Tel"].ToString();
            this.GridView1.Columns[2].HeaderText = compIdioma["GV_Corr"].ToString();
            this.GridView1.Columns[3].HeaderText = compIdioma["GV_Dire"].ToString();
            this.GridView1.Columns[4].HeaderText = compIdioma["GV_Nit"].ToString();
            this.GridView1.Columns[5].HeaderText = compIdioma["GV_Calif"].ToString();
            this.GridView1.Columns[6].HeaderText = compIdioma["GV_Mem"].ToString();
            //this.GridView1.Columns[5].HeaderText = compIdioma["GV_Dir"].ToString();
        }
        catch (Exception ex)
        { }

        U_AuxQuejAdm res = log.pageLoad(Session["Sesion"], Session["sesion"], GridView1.Rows.Count);
        GridView1.UseAccessibleHeader = true;
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + res.Redir + "');", true);

    }
}