using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_Tienda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //IDIOMA
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 16;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        L_Idioma idiot = new L_Idioma();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.title.InnerText= compIdioma["title"].ToString();
        }
        catch (Exception ex)
        {

        }
    }
    protected void RP_MostrarProducto_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
    }
}