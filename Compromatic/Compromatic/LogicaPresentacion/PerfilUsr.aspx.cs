using System;
using System.Collections;
using System.Data;
using Logica;
using Utilitarios;

public partial class Presentacion_PerfilUsr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_PerfilUsr logic = new L_PerfilUsr();
        UEUsuario usr = logic.cargar_datos(Session["Sesion"]);
            LB_Nombre.Text = usr.NomUsr;
            LB_Apellidos.Text = usr.ApelUsr;
            LB_Cc.Text = usr.CcUsr;
            LB_Telefono.Text = usr.TelUsr;
            LB_Direccion.Text = usr.DirUsr;
            LB_Correo.Text =usr.CorreoUsr;
            LB_Calificacion.Text = usr.Calificacion;
            string rutaFoto = usr.RutaArch;
            IMG_FotoPerfil.ImageUrl=rutaFoto;
        //IDIOMA
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 2;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        L_Idioma idiot = new L_Idioma();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.perf_client.InnerHtml= compIdioma["perf_client"].ToString();
            this.inf_client.InnerText= compIdioma["inf_client"].ToString();
            this.nomb_usr.InnerText= compIdioma["nomb_usr"].ToString();
            this.apell_usr.InnerText = compIdioma["apell_usr"].ToString();
            this.num_id.InnerText= compIdioma["num_id"].ToString();
            this.num_tel.InnerText= compIdioma["num_tel"].ToString();
            this.dir_usr.InnerText = compIdioma["dir_usr"].ToString();
            this.email_usr.InnerText= compIdioma["email_usr"].ToString();
            this.cal_usr.InnerText= compIdioma["cal_usr"].ToString();
        }
        catch (Exception ex)
        {

        }
        String texto = "redireccionar('"+ usr.Redireccion +"');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", texto, true);

    }
}

  
