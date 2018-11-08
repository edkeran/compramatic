using System;
using System.Data;
using System.Web.UI;
using Utilitarios;
using Logica;
using System.Collections;

public partial class Presentacion_CambiarPassUsr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Debo Cambiar Esto Por Mi Script
        L_CambiarPass_Usr logic = new L_CambiarPass_Usr();
        String response= logic.page_load(Session["Sesion"]);
        String texto = "<script> redireccionar('" + response+ "')</script>";
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 4;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.usr_ch_pass.InnerText= compIdioma["usr_ch_pass"].ToString();
            this.pass_usr.InnerText= compIdioma["pass_usr"].ToString();
            this.ant_pass.InnerText= compIdioma["ant_pass"].ToString();
            this.new_pass.InnerText= compIdioma["new_pass"].ToString();
            this.new_pass2.InnerText= compIdioma["new_pass2"].ToString();
            Btn_Modificar.Text= compIdioma["Btn_Modificar"].ToString();
        }
        catch (Exception ex)
        {

        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", texto);
    }

    public void Modal(String mensaje,String Redireccion)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');var mod=$('#modal-dialog');$('#myBtn').click(function(){$('#modal-dialog').modal('hide');redireccionar ('" + Redireccion + "')});</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }

    protected void BtnCambiarInf_Click(object sender, EventArgs e)
    {
        DataTable datos = (DataTable)Session["Sesion"];
        L_CambiarPass_Usr pass = new L_CambiarPass_Usr();
        String response=pass.cambiar_contrasena(datos, TB_Pass1.Text, TB_Pass2.Text, TB_Pass3.Text);
        String []data=response.Split('/');
        Modal(data[0],data[1]);
    }

    /**
     *if (TB_Pass1.Text != datos.Rows[0]["passUsuario"].ToString())
        {
            Modal("Contraseña erronea.");
        }
        else if(TB_Pass2.Text!=TB_Pass3.Text)
        {
            Modal("La confirmación de contraseña no es correcta, recuerda que la contraseña nueva debe ser escrita dos veces para aprobar el cambio de contraseña.");
        }
        else if(TB_Pass2.Text.Length<8)
        {
            Modal("Contraseña nueva corta.");
        }
        else if (TB_Pass1.Text == TB_Pass2.Text || TB_Pass1.Text == TB_Pass3.Text)
        {
            Modal("Contraseña nueva es igual a la anterior.");
        }
        else
        {
            DAOUsuario cambiar = new DAOUsuario();
            EUsuario user = new EUsuario();
            user.PassUsr = TB_Pass2.Text;
            user.IdUsr=int.Parse(datos.Rows[0]["idUsuario"].ToString());
            cambiar.CambiarPass(user,datos.Rows[0]["nomUsuario"].ToString());
            Modal("Contraseña cambiada con éxito.");
            Response.Redirect("LoginUsr.aspx");
        }
     *
     * 
     **/
}