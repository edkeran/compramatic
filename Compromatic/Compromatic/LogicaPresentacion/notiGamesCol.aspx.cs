using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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