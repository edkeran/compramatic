using System;
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
    }
    /**
     *if (Session["Sesion"] == null)
            {
                DropDownPerfilUsr.Visible = false;
            }
            else
            {
                DataTable user = (DataTable)Session["Sesion"];
                String rutaFoto = user.Rows[0]["rutaArchivo"].ToString() + user.Rows[0]["nomArchivo"].ToString();

                IMG_PerfilHeatherNR.ImageUrl = rutaFoto;
                LB_NombreHeatherNR.Text = user.Rows[0]["nomUsuario"].ToString();
            } 
     **/
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
        Session["Sesion"] = null;
        Response.Redirect("LoginUsr.aspx");
    }
}
