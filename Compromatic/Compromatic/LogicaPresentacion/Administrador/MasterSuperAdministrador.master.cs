using System;
using System.Web;
using System.Web.UI;
using Logica;
using Utilitarios;
using System.Collections;

public partial class Presentacion_MasterSuperAdministrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_MasterAdmin logica = new L_MasterAdmin();
        U_AuxMasterAdmin response=logica.page_load(Session["sesion"]);
        Numero_noti.Text = response.Numero_noti1;
        cantidadAceptadas.Text = response.CantidadAceptadas;
        cantidadRechazadas.Text = response.CantidadRechazadas;
        cantidadPendientes.Text = response.CantidadPendientes;
        TotalAceptadas.Text = response.TotalAceptadas1;
        TotalRechazadas.Text = response.TotalRechazadas1;
        TotalPendientes.Text = response.TotalPendientes1;
        TotalSolicitudes.Text = response.TotalSolicitudes1;
        FotoPerfil.ImageUrl = response.FotoPerfil1;
        FotoPerfil2.ImageUrl = response.FotoPerfil1;
        NombrePerfil.Text = response.NombrePerfil1;
        NombrePerfil2.Text = response.NombrePerfil21;

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 25;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.title.Text = compIdioma["title"].ToString();
            this.adm.InnerText = compIdioma["adm"].ToString();
            this.solic.InnerText = compIdioma["solic"].ToString();
            this.emp_acept.InnerText = compIdioma["emp_acept"].ToString();
            this.emp_rech.InnerText = compIdioma["emp_rech"].ToString();
            this.emp_pend.InnerText = compIdioma["emp_pend"].ToString();
            this.rep_cry.InnerHtml = "<span></span>"+ compIdioma["rep_cry"].ToString();
            this.Salir.Text= compIdioma["Salir"].ToString();
            this.contr.InnerText= compIdioma["contr"].ToString();
            this.navigate_menu.InnerText= compIdioma["navigate_menu"].ToString();
            this.main.InnerText= compIdioma["main"].ToString();
            this.quej.InnerText= compIdioma["quej"].ToString();
            this.repor.InnerText= compIdioma["repor"].ToString();
            this.usr.InnerHtml= compIdioma["usr"].ToString()+"<span class='label label-theme m-l-5'></span>";
            this.cliet.InnerHtml = "<b class='caret pull-right'></b>"+ compIdioma["cliet"].ToString();
            this.ver_all.InnerText = compIdioma["ver_all"].ToString();
            this.empre.InnerHtml = "<b class='caret pull-right'></b>"+ compIdioma["empre"].ToString();
            this.ver_all2.InnerText= compIdioma["ver_all"].ToString();
            this.tot_vent.InnerText= compIdioma["tot_vent"].ToString();
            this.request.InnerText= compIdioma["request"].ToString();
            this.accep.InnerText= compIdioma["accep"].ToString();
            this.rech.InnerText= compIdioma["rech"].ToString();
            this.pend.InnerText= compIdioma["pend"].ToString();
            this.admi_cat.InnerText= compIdioma["admi_cat"].ToString();
            this.adm_mem.InnerText= compIdioma["adm_mem"].ToString();
            this.adm_mot.InnerText= compIdioma["adm_mot"].ToString();
            //this.respo.InnerText = compIdioma["respo"].ToString();
        }
        catch (Exception ex)
        { }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + response.Redireccion + "');", true);
    }
    
    protected void ImageNotificacionPendientes_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SolicitudesPendientes.aspx");
    }

    protected void Salir_Click(object sender, EventArgs e)
    {
        Session["Sesion"] = null;
        Response.Redirect("LoginUsr.aspx");
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
    }
    protected void ImageNotificacionRechazadas_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SolicitudesRechazadas.aspx");
    }
    protected void ImageNotificacionAceptadas_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SolicitudesAceptadas.aspx");
    }
}
