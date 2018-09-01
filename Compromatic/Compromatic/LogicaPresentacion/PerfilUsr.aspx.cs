using System;
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
        String texto = "redireccionar('"+ usr.Redireccion +"');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", texto, true);

    }
}

  
