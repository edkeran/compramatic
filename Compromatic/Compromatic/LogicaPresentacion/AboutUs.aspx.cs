using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logica;
using Utilitarios;

public partial class Presentacion_AboutUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 8;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.que_hac.InnerText= compIdioma["que_hac"].ToString();
            this.desc.InnerHtml= compIdioma["desc"].ToString();
            this.title.InnerText= compIdioma["title"].ToString();
            this.explore.InnerText= compIdioma["explore"].ToString();
            this.profile.InnerText= compIdioma["profile"].ToString();
            this.desc2.InnerText= compIdioma["desc2"].ToString();
            this.atencion.InnerText= compIdioma["atencion"].ToString();
            this.desc3.InnerText= compIdioma["desc3"].ToString();
            this.comp.InnerText= compIdioma["comp"].ToString();
            this.desc4.InnerText= compIdioma["desc4"].ToString();
            this.conec.InnerText= compIdioma["conec"].ToString();
            this.desc5.InnerText= compIdioma["desc5"].ToString();
            this.comp_inv.InnerText= compIdioma["comp_inv"].ToString();
            this.desc6.InnerText= compIdioma["desc6"].ToString();
        }
        catch (Exception ex)
        { }
    }
}