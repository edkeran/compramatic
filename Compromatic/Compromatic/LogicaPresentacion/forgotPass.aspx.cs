using System;
using Logica;
using Utilitarios;

public partial class Presentacion_forgotPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!TB_Correo.Text.Equals("")) {
            L_ForgotPass logi = new L_ForgotPass();
            String res=logi.pass(TB_Correo.Text);
        }
        else
        {
            //RETORNO UN MENSAJE PARA EL ALERT

        }
    }
}