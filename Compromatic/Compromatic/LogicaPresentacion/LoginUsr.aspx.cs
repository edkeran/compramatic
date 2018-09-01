using System;
using System.Web.UI;
using Logica;
using Utilitarios;

public partial class Presentacion_LoginUsr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Validacion De La Sesion sin un IF Explicito
        L_LogginUsr log = new L_LogginUsr();
        String session = log.validar_session(Session["Sesion"],IsPostBack);
        Page.ClientScript.RegisterStartupScript(this.GetType(),"Script" ,"redireccionar('"+session+"');",true);
    }
    public void Modal(String mensaje,String page)
    {
        //Funcion Elegante Ya Recorde LOL
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');var mod=$('#modal-dialog');$('#myBtn').click(function(){$('#modal-dialog').modal('hide');window.location = '"+page+"'});</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        //PREGUNTA POR LOS DATOS DEL DROPDOWNLIST
        L_LogginUsr log = new L_LogginUsr();
        //LLAMO A LA FUNCION DE LOGICA QUE VALIDA EL LOGGIN
        U_aux_loggin respuesta = log.Loggin(DDL_TipoLog.SelectedValue,TB_Email.Text,TB_Pass.Text);
        Session["Sesion"] = respuesta.Datos;
        Session["IdEmpresa"] = respuesta.Id_empresa;
        Modal(respuesta.Modal_message,respuesta.New_page);
    }
}

/**
 * 
 *
 *Codigo Original
if (DDL_TipoLog.SelectedValue=="0")
{
    IADEmpresa IAD_Empresa = new IADEmpresa();
    DataTable Empresa = IAD_Empresa.Login(TB_Email.Text, TB_Pass.Text);

    if(Empresa.Rows.Count>0)
    {
        Session["Sesion"] = Empresa;
        Session["IdEmpresa"] = Empresa.Rows[0]["idEmpresa"].ToString(); ;
        Response.Redirect("PerfilEmpresa.aspx");
        
    }
    else
    {
        Modal("La contraseña y/o el correo no coinciden.");
       
    }
    
}
else
{
    DAOUsuario login = new DAOUsuario();
    EUsuario user = new EUsuario();
    user.PassUsr = TB_Pass.Text;
    user.CorreoUsr = TB_Email.Text;
    DataTable datos = login.Login(user);

    
    if (datos.Rows.Count > 0)
    {
        if (DDL_TipoLog.SelectedValue == "2")
        {
            Session["Sesion"] = datos;
            Response.Redirect("PrincipalAdministrador.aspx");
        }                
        else if (int.Parse(datos.Rows[0]["estadoUsuario"].ToString()) == 0)
        {
            user.IdUsr = int.Parse(datos.Rows[0]["idUsuario"].ToString());
            Modal("Qué bueno que regreses!");
            login.BloqueoUser(user,1,"");
            datos = login.Login(user);
            Session["Sesion"] = datos;
            Response.Redirect("Home.aspx");
        }
        else if (int.Parse(datos.Rows[0]["estadoUsuario"].ToString()) == 1 && datos.Rows[0]["idTipo"].ToString() == "3")
        {
            Session["Sesion"] = datos;
            Response.Redirect("Home.aspx");
        }
        else
        {
           Modal("Estas bloqueado por un tiempo, regresa cuando acabe tu sansion.");
           
        }
    }
    else
    {
        Modal("La contraseña y/o el correo no coinciden.");
       
      
    }

}
 * 
 * */

