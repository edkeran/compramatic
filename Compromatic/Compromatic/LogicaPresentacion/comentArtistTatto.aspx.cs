using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class Presentacion_comentArtistTatto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //validar postback
        try
        {
            L_comentArtistTatt logi = new L_comentArtistTatt();
            logi.validar_postback(IsPostBack);
            wsTattoSt.WebServiceSoapClient serv = new wsTattoSt.WebServiceSoapClient();
            DataSet artistas = serv.Artistas();
            //Seteando Idiomas
            L_Idioma idiot = new L_Idioma();
            Object sesidioma = Session["idiomases"];
            Int32 formulario = 44;
            Int32 idiom = Convert.ToInt32(sesidioma);
            Hashtable compIdioma = new Hashtable();
            idiot.mostraridioma(formulario, idiom, compIdioma);
            try
            {
                this.title.InnerHtml = compIdioma["title"].ToString();
                this.BTN_Get.Text= compIdioma["BTN_Get"].ToString();
            }
            catch (Exception ex)
            { }

            try
            {
                DDL_artist.DataSource = artistas;
                DDL_artist.DataTextField = "Nombre";
                DDL_artist.DataValueField = "Cedula";
                DDL_artist.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {

        }
        
    }

    protected void BTN_Get_Click(object sender, EventArgs e)
    {
        long id = long.Parse(DDL_artist.SelectedValue);
        wsTattoSt.WebServiceSoapClient serv = new wsTattoSt.WebServiceSoapClient();
        try
        {
            DataSet comment = serv.Comentarios(id);
            GV_Comment.DataSource = comment;
            GV_Comment.DataBind();
            GV_Comment.Visible = true;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}