using System;
using System.Collections;
using System.Web.UI;
using Logica;
using Utilitarios;

public partial class Presentacion_MasterHome : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_Master_Home logica = new L_Master_Home();
        //CAMBIAR FUNCIONES
        PerfilUsr.Visible = logica.validaciones(IsPostBack, Session["Sesion"]);
        U_aux_master_home info = new U_aux_master_home();
        info = logica.generar_datos_session(IsPostBack, Session["Sesion"]);
        IMG_UsuarioBarraHome.ImageUrl = info.RutaFoto;
        LB_NombreUsuarioBarraHome.Text = info.NomUsuario;
        Registro.Visible = info.RegistroVisible;

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        //Object sesidioma = Session["idiomases"];
        Object sesidioma = 1;
        Int32 formulario = 7;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.man_usr.InnerText = compIdioma["man_usr"].ToString();
            this.tien.InnerText= compIdioma["tien"].ToString();
            this.tienda.InnerText = compIdioma["tien"].ToString();
            this.pags.InnerHtml= compIdioma["pags"].ToString()+ " <i class='fa fa-angle-down'></i> <span class='arrow top'></span>";
            this.perf.InnerText= compIdioma["perf"].ToString();
            this.about_us.InnerText= compIdioma["about_us"].ToString();
            this.who_are.InnerText= compIdioma["who_are"].ToString(); 
            this.regi.InnerHtml = compIdioma["regi"].ToString()+" <i class='fa fa-angle-down'></i> <span class='arrow top'></span>";
            this.as_usr.InnerText = compIdioma["as_usr"].ToString();
            this.as_company.InnerText = compIdioma["as_company"].ToString();
            this.start_session.InnerText = compIdioma["start_session"].ToString();

        }
        catch (Exception ex)
        {}
    }
    //NO CAMBIAR FUNCION
    protected void BTN_LogOut_Click(object sender, EventArgs e)
    {
        Session["Sesion"] = null;
        Response.Redirect("Home.aspx");
    }
    //No Cambiar Funcion
    public void Modal(String mensaje)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }
    //CAMBIAR FUNCIONALIDAD
    protected void BTN_Buscar_Click(object sender, EventArgs e)
    {
        L_Master_Home lgc = new L_Master_Home();
        U_aux_master_home data = new U_aux_master_home();
        data=lgc.boton_buscar(TB_Search.Text);
        Session["Tienda"] = data.Productos;
        String url = data.Url;
        MensajeModal.Text= data.Modal_Info1;
        //REDIRECCION ES UN JS
        String texto ="redireccionar_Home('"+url+"');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", texto,true);
    }

}
