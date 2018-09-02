using System;
using System.Collections.Generic;
using System.Data;
using Logica;

public partial class Presentacion_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_AgregarProducto logica = new L_AgregarProducto();
        String redireccion = logica.page_load(IsPostBack,Session["Sesion"]);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + redireccion + "');", true);
    }


    protected void AñadirProducto(object sender, EventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        L_AgregarProducto logica = new L_AgregarProducto();
        logica.AgregarProducto(TB_Nombre.Text, int.Parse(TB_Cantidad.Text), double.Parse(TB_Precio.Text), TB_Descripcion.Text, int.Parse(DDL_Categoria.SelectedValue), int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()),Empresa.Rows[0]["nomEmpresa"].ToString());
        Response.Redirect("AdministrarProducto.aspx");
    }

    protected void BTN_Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministrarProducto.aspx");
    }
}