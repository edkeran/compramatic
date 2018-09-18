using System;
using System.Collections;
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

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 19;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.title.Text = compIdioma["title"].ToString();
            this.data.InnerText = compIdioma["data"].ToString();
            String attr = "placeholder";
            this.TB_Email.Attributes.Remove(attr);
            this.TB_Email.Attributes.Add(attr, compIdioma["TB_Email"].ToString());
            this.TB_Pass.Attributes.Remove(attr);
            this.TB_Pass.Attributes.Add(attr, compIdioma["TB_Pass"].ToString());
            this.DDL_TipoLog.Items[0].Text = compIdioma["EMP"].ToString();
            this.DDL_TipoLog.Items[1].Text = compIdioma["CLIEN"].ToString();
            this.DDL_TipoLog.Items[2].Text = compIdioma["ADMIN"].ToString();
            this.Btn_Login.Text= compIdioma["Btn_Login"].ToString();
            this.LB_M1.Text= compIdioma["LB_M1"].ToString();
            this.LB_M2.Text= compIdioma["LB_M2"].ToString();
            this.LB_E2.Text= compIdioma["LB_M2"].ToString();
            this.LB_E1.Text= compIdioma["LB_E1"].ToString();
            this.here1.InnerText= compIdioma["here"].ToString();
            this.here2.InnerText= compIdioma["here"].ToString();
            this.here3.InnerText= compIdioma["here"].ToString();
            this.LB_Contra.Text= compIdioma["LB_Contra"].ToString();
            this.respo.InnerText= compIdioma["respo"].ToString();
        }
        catch (Exception ex)
        { }
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

