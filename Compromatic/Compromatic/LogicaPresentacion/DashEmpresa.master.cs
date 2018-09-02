using System;
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
            //sideBar
            IMG_FotoPerfilSideBar.ImageUrl = rutaFoto;
            LB_NombreSideBar.Text = Empresa.Rows[0]["nomEmpresa"].ToString();
            //End sideBar
            //Heather Navigation Right
            IMG_PerfilHeatherNR.ImageUrl = rutaFoto;
            LB_NombreHeatherNR.Text = Empresa.Rows[0]["nomEmpresa"].ToString();
        }catch(Exception ex)
        {
            Response.Redirect("LoginUsr.aspx");
        }
    }

    /**
     *  if (Session["Sesion"] == null)
            {
                Response.Redirect("LoginUsr.aspx");
            }
     **/


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
