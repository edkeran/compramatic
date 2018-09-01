using System;
using System.Collections.Generic;
using System.Data;

public partial class Presentacion_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Sesion"] == null)
            {
                Response.Redirect("LoginUsr.aspx");
            }
            DataTable Empresa = (DataTable)Session["Sesion"];
            if (Empresa.Rows[0]["idTipo"].ToString() != "2")
            {
                Response.Redirect("LoginUsr.aspx");
            }
            if (int.Parse(Empresa.Rows[0]["estadoEmpresa"].ToString()) != 1)
            {
                Response.Redirect("PerfilEmpresa.aspx");
            }
        }
    }


    protected void AñadirProducto(object sender, EventArgs e)
    {

        DataTable Empresa = (DataTable)Session["Sesion"];
        IADProducto IAD_Producto = new IADProducto();
        IAD_Producto.AgregarProducto(TB_Nombre.Text, int.Parse(TB_Cantidad.Text), double.Parse(TB_Precio.Text), TB_Descripcion.Text, int.Parse(DDL_Categoria.SelectedValue), int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()),Empresa.Rows[0]["nomEmpresa"].ToString());
        Response.Redirect("AdministrarProducto.aspx");
    }
    protected void BTN_Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministrarProducto.aspx");
    }
}