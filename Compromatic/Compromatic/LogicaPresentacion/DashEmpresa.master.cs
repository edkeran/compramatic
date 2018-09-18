using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Logica;

public partial class Presentacion_DashEmpresa : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_DashEmpresa logica = new L_DashEmpresa();
            String redireccion = logica.page_load(Session["Sesion"]);
            DataTable Empresa = (DataTable)Session["Sesion"];
            string rutaFoto = Empresa.Rows[0]["rutaArchivo"].ToString() + Empresa.Rows[0]["nomArchivo"].ToString();
            IMG_FotoPerfilSideBar.ImageUrl = rutaFoto;
            LB_NombreSideBar.Text = Empresa.Rows[0]["nomEmpresa"].ToString();
            IMG_PerfilHeatherNR.ImageUrl = rutaFoto;
            LB_NombreHeatherNR.Text = Empresa.Rows[0]["nomEmpresa"].ToString();

            //Seteando Idiomas
            L_Idioma idiot = new L_Idioma();
            Object sesidioma = Session["idiomases"];
            Int32 formulario = 11;
            Int32 idiom = Convert.ToInt32(sesidioma);
            Hashtable compIdioma = new Hashtable();
            idiot.mostraridioma(formulario, idiom, compIdioma);
            try
            {
                this.title.Text= compIdioma["title"].ToString();
                this.ver_perf.InnerText= compIdioma["ver_perf"].ToString();
                this.productos.InnerText= compIdioma["productos"].ToString();
                this.add_prod.InnerText= compIdioma["add_prod"].ToString();
                this.adm_pro.InnerText= compIdioma["adm_pro"].ToString();
                this.low_inv.InnerText= compIdioma["low_inv"].ToString();
                this.pet.InnerText= compIdioma["pet"].ToString();
                this.mem.InnerText= compIdioma["mem"].ToString();
                this.cali.InnerText= compIdioma["cali"].ToString();
                this.BTN_Enviar.Text= compIdioma["BTN_Enviar"].ToString();
            }
            catch (Exception ex)
            { }
        }
        catch(Exception ex)
        {
            Response.Redirect("LoginUsr.aspx");
        }
    }

  
    protected void BorrarSesion(object sender, EventArgs e)
    {
        Session["Sesion"] = null;
        Response.Redirect("LoginUsr.aspx");
    }

    protected void BTN_Enviar_Click(object sender, EventArgs e)
    {

        DataTable Empresa = (DataTable)Session["Sesion"];
        L_DashEmpresa logica = new L_DashEmpresa();
        logica.RegistrarPqr(TB_Descripcion.Text, int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()), int.Parse(DDL_PQR.SelectedValue),Empresa.Rows[0]["nomEmpresa"].ToString());
        TB_Descripcion.Text = "";
    }
}
