using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_MasterIndex : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (Session["Sesion"] == null)
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

    }
    protected void TB_Buscar_Click(object sender, EventArgs e)
    {
        DAOHome datos = new DAOHome();
        String palabra = TB_Search.Text.ToString();
        palabra = palabra.Replace(' ','|');
        Session["Tienda"]=datos.Buscador(palabra);
        Response.Redirect("Tienda.aspx");
    }
    protected void Btn_Log_Out_Click(object sender, ImageClickEventArgs e)
    {
        Session["Sesion"] = null;
        Response.Redirect("LoginUsr.aspx");
    }
}
