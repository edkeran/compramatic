using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class Presentacion_notiGamesCol : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        swGamesCol.ServiceToken token = new swGamesCol.ServiceToken();
        try
        {
            swGamesCol.Facebook_servideSoapClient etiqueta = new swGamesCol.Facebook_servideSoapClient();

            {
                token.sToken = "compramaticfHFJO310ucxAKiDxjUwl";
            };

            string sToken = etiqueta.AutenticacionCliente(token);

            if (sToken.Equals("-1"))
            {
                Response.Write("<Script Language='JavaScript'>parent.alert('Token invalido');</Script>");
                throw new Exception("token invalido");
            }
            token.AutenticacionToken = sToken;
            etiqueta.postpc(token);

            //string m = "probando mensajes";

            //Response.Write("<Script Language='JavaScript'>parent.alert('" + m + "');</Script>");
            GV_miPost.DataSource = this.obtenerPost(token);
            GV_miPost.DataBind();
            //Seteando Idiomas
            L_Idioma idiot = new L_Idioma();
            Object sesidioma = Session["idiomases"];
            Int32 formulario = 41;
            Int32 idiom = Convert.ToInt32(sesidioma);
            Hashtable compIdioma = new Hashtable();
            idiot.mostraridioma(formulario, idiom, compIdioma);
            try
            {
                this.title.InnerHtml = compIdioma["title"].ToString();
            }
            catch (Exception ex)
            { }
        }
        catch (Exception ex)
        {

            Response.Write("<Script Language='JavaScript'>parent.alert('" + ex.Message + "');</Script>");
        }
    }

    private DataTable obtenerPost(swGamesCol.ServiceToken p)
    {
        swGamesCol.Facebook_servideSoapClient eti = new swGamesCol.Facebook_servideSoapClient();
        DataTable dato = new DataTable();
        dato = eti.noticias(p);
        return dato;
    }
}