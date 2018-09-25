using System;
using System.Collections;
using System.Web.UI;
using Logica;
using Utilitarios;

public partial class Presentacion_MasterIndex : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_MasterIndex logi = new L_MasterIndex();
        U_aux_MasterIndex re=logi.page_load(Session["Sesion"]);
        DropDownPerfilUsr.Visible = re.DLL_perfilUsr1;
        IMG_PerfilHeatherNR.ImageUrl = re.RutaFoto;
        LB_NombreHeatherNR.Text = re.NombreHeather;

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 18;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.prof.InnerHtml= compIdioma["prof"].ToString()+ "  <i class='fa fa-user'></i>";
            this.edit_info.InnerHtml = compIdioma["edit_info"].ToString() + "    <i class='fa fa-edit'></i>";
        }
        catch (Exception ex)
        { }
    }
   
    protected void TB_Buscar_Click(object sender, EventArgs e)
    {
        //DAOHome datos = new DAOHome();
        String palabra = TB_Search.Text.ToString();
        palabra = palabra.Replace(' ','|');
        L_MasterIndex logica = new L_MasterIndex();
        Session["Tienda"]=logica.TB_Buscar(palabra);
        Response.Redirect("Tienda.aspx");
    }

    protected void Btn_Log_Out_Click(object sender, ImageClickEventArgs e)
    {
        L_Master_Home logica = new L_Master_Home();
        logica.log_out(Session["sesion"], Session["Sesion"]);
        Session["Sesion"] = null;
        Response.Redirect("LoginUsr.aspx");
    }
}
