using System;
using System.Collections.Generic;
using Logica;
using Utilitarios;

public partial class Presentacion_PublicacionesUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_PublicUsr logi = new L_PublicUsr();
        List<UEUPublic_User> data = null;
        data=logi.consultarPublicaciones();
        GV_Comments.DataSource = data;
        GV_Comments.DataBind();
    }
}