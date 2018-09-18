using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Logica;

public partial class Presentacion_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_AgregarProducto logica = new L_AgregarProducto();
        String redireccion = logica.page_load(IsPostBack,Session["Sesion"]);

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 12;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.title.InnerText = compIdioma["title"].ToString();
            this.add_pro.InnerText= compIdioma["add_pro"].ToString();
            this.inf_prod1.InnerHtml= compIdioma["inf_prod1"].ToString()+ "<small id='desc1'>"+ compIdioma["desc1"].ToString()+ "</small>";
            this.inf_prod2.InnerHtml = compIdioma["inf_prod2"].ToString() + "<small id='desc2'>" + compIdioma["desc2"].ToString() + "</small>";
            this.end_pro.InnerHtml= compIdioma["end_pro"].ToString() + "<small id='desc3'>" + compIdioma["desc3"].ToString() + "</small>";
            this.ident.InnerText= compIdioma["ident"].ToString();
            this.nom.InnerText= compIdioma["nom"].ToString();
            this.desc.InnerText= compIdioma["desc"].ToString();
            this.inven.InnerText = compIdioma["inven"].ToString();
            this.cant.InnerText = compIdioma["cant"].ToString();
            this.pric.InnerText= compIdioma["pric"].ToString();
            this.cat.InnerText= compIdioma["cat"].ToString();
            this.exito.InnerText= compIdioma["exito"].ToString();
            this.desc_exit.InnerText= compIdioma["desc_exit"].ToString();
            this.BTN_Cancelar.Text= compIdioma["BTN_Cancelar"].ToString();
            this.BTN_Guardar.Text= compIdioma["BTN_Guardar"].ToString();
        }
        catch (Exception ex)
        { }
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