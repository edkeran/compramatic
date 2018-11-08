using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class Presentacion_ComentariosEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //VALIDAR PAGE_LOAD
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 39;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.comm.InnerText = compIdioma["comm"].ToString();
            this.ComEm.InnerText = compIdioma["ComEm"].ToString();
            this.nom.InnerText = compIdioma["nom"].ToString();
            this.crrUsr.InnerText = compIdioma["crrUsr"].ToString();
            this.comUsr.InnerText = compIdioma["comUsr"].ToString();
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}