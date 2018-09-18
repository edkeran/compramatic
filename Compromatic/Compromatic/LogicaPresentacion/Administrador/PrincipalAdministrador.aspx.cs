using System;
using System.Web;
using System.Web.UI;
using Utilitarios;
using Logica;
using System.Collections;

public partial class Presentacion_PrincipalAdministrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_PrinciAdmin logica = new L_PrinciAdmin();
        UAuxPrinciAdmin res = logica.page_load(Session["sesion"]);
        L_Usuarios.Text = res.L_Usuarios1;
        L_Empresas.Text = res.L_Empresas1;
        L_totalVentas.Text = res.L_totalVentas1;
        L_Pqr.Text = res.L_Pqr1;

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 26;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.welco.InnerText = compIdioma["welco"].ToString();
            this.main.InnerHtml = compIdioma["main"].ToString() + " <small id='comp' runat='server'>"+ compIdioma["comp"].ToString() + "</small>";
            this.ven.InnerText = compIdioma["ven"].ToString();
            this.ven_his.InnerText= compIdioma["ven_his"].ToString();
            this.emp_reg.InnerText= compIdioma["emp_reg"].ToString();
            this.act_emp.InnerText= compIdioma["act_emp"].ToString();
            this.client_reg.InnerText= compIdioma["client_reg"].ToString();
            this.usr_act.InnerText= compIdioma["usr_act"].ToString();
            this.pqr_se.InnerText= compIdioma["pqr_se"].ToString();
            this.L_texto.Text= compIdioma["L_texto"].ToString();

            //this.bloq_perfi.InnerText = compIdioma["bloq_perfi"].ToString();
        }
        catch (Exception ex)
        {

        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + res.Redireccion + "');", true);
    }
}