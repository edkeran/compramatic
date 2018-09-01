using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_DashEmpresa : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Sesion"] == null)
        {
            Response.Redirect("LoginUsr.aspx");
        }
        DataTable Empresa = (DataTable)Session["Sesion"];
        string rutaFoto = Empresa.Rows[0]["rutaArchivo"].ToString() + Empresa.Rows[0]["nomArchivo"].ToString();
        //sideBar
        IMG_FotoPerfilSideBar.ImageUrl = rutaFoto;
        LB_NombreSideBar.Text = Empresa.Rows[0]["nomEmpresa"].ToString();
        //End sideBar
        //Heather Navigation Right
        IMG_PerfilHeatherNR.ImageUrl = rutaFoto;
        LB_NombreHeatherNR.Text = Empresa.Rows[0]["nomEmpresa"].ToString();
    }

    protected void BorrarSesion(object sender, EventArgs e)
    {
        Session["Sesion"] = null;
        Response.Redirect("LoginUsr.aspx");
    }
    protected void BTN_Enviar_Click(object sender, EventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        IADPqr IAD_Pqr = new IADPqr();
        IAD_Pqr.RegistrarPqr(TB_Descripcion.Text, int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()), int.Parse(DDL_PQR.SelectedValue),Empresa.Rows[0]["nomEmpresa"].ToString());
        TB_Descripcion.Text = "";
    }
}
