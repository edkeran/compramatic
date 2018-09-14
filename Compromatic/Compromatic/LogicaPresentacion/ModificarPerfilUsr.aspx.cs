using System;
using System.Data;
using System.Web.UI;
using Utilitarios;
using Logica;
using System.Collections;

public partial class Presentacion_ModificarPerfilUsr : System.Web.UI.Page
{
    protected string nom;
    protected void Page_Load(object sender, EventArgs e)
    {
        L_ModificarPerfilUsr logic = new L_ModificarPerfilUsr();
        UEUsuario user = logic.page_loading(Session["Sesion"]);
        IMG_FotoPerfil.ImageUrl = user.NomArch;
        LB_Nombre.Text = user.NomUsr;
        LB_Apellido.Text = user.ApelUsr;
        LB_Telefono.Text = user.TelUsr;
        LB_Cc.Text = user.CcUsr;
        LB_Correo.Text = user.CorreoUsr;
        LB_Direccion.Text = user.DirUsr;
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        //Object sesidioma = Session["idiomases"];
        Object sesidioma = 1;
        Int32 formulario = 3;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.perf_client.InnerText = compIdioma["perf_client"].ToString();
            this.mod_client.InnerText = compIdioma["mod_client"].ToString();
            this.load_img.InnerText = compIdioma["load_img"].ToString();
            this.names_usr.InnerText = compIdioma["names_usr"].ToString();
            this.apell_usr.InnerText = compIdioma["apell_usr"].ToString();
            this.cc_usr.InnerText = compIdioma["cc_usr"].ToString();
            this.tel_usr.InnerText = compIdioma["tel_usr"].ToString();
            this.dir_usr.InnerText = compIdioma["dir_usr"].ToString();
            this.email_usr.InnerText = compIdioma["email_usr"].ToString();
            this.BTN_CambiarInf.Text= compIdioma["BTN_CambiarInf"].ToString();
            this.btn_photo.InnerHtml = "<i class='fa fa-camera'></i>" + compIdioma["btn_photo"].ToString()+ "<span class='caret'></span>";
            this.BTN_QuitarFoto.Text= compIdioma["BTN_QuitarFoto"].ToString();
            this.BTN_CambiarFoto.Text= compIdioma["BTN_CambiarFoto"].ToString();
        }
        catch (Exception ex)
        {

        }

        String texto = "redireccionar('" + user.Redireccion + "');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scrt", texto, true);
    }


    protected void CambiarInf_Click(object sender, EventArgs e)
    {
        DataTable datos = (DataTable)Session["Sesion"];
        L_ModificarPerfilUsr logica = new L_ModificarPerfilUsr();
        UEUsuario newInfo = new UEUsuario();
        newInfo.NomUsr = TB_Nombre.Text;
        newInfo.ApelUsr = TB_Apellido.Text;
        newInfo.TelUsr = TB_Telefono.Text;
        newInfo.CcUsr = TB_Cc.Text;
        newInfo.CorreoUsr = TB_Correo.Text;
        newInfo.DirUsr = TB_Direccion.Text;
        newInfo.IdUsr= int.Parse(datos.Rows[0]["idUsuario"].ToString());
        U_Modificar_Pfi_Usr res= logica.cambiar_informacion(datos, TB_Correo.Text, newInfo);
        Session["Sesion"] = res.Datos;
        Modal(res.Mensage,res.Pagina_redir);
        //Response.Redirect(res.Pagina_redir);
    }


    public void Modal(String mensaje,String pagina)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');redireccionar('"+pagina+"');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", texto);
        MensajeModal.Text = mensaje;
    }

    protected void BTN_CambiarFoto_Click(object sender, EventArgs e)
    {
        DataTable datos = (DataTable)Session["Sesion"];
        String extension = System.IO.Path.GetExtension(FU_CambiarFoto.PostedFile.FileName);
        String nombreArchivo = datos.Rows[0]["idUsuario"].ToString();
        String saveLocation = (Server.MapPath("~\\Archivos\\FotosPerfil") + "\\" + nombreArchivo + extension);
        L_ModificarPerfilUsr logic = new L_ModificarPerfilUsr();
        String SaveLocationAnt = (Server.MapPath("~\\Archivos\\FotosPerfil") + "\\" + datos.Rows[0]["nomArchivo"].ToString());
        U_Modificar_Pfi_Usr res = logic.cambiar_foto(saveLocation,FU_CambiarFoto.PostedFile.InputStream,extension,datos,nombreArchivo, SaveLocationAnt);
        //Session["Sesion"] = res.Datos;
        Modal(res.Mensage, res.Pagina_redir);
    }

    
    protected void BTN_QuitarFoto_Click(object sender, EventArgs e)
    {
        DataTable datos = (DataTable)Session["Sesion"];
        //DAOUsuario foto = new DAOUsuario();
        L_ModificarPerfilUsr logica = new L_ModificarPerfilUsr();
        UEUsuario user = new UEUsuario();
        String SaveLocationAnt = (Server.MapPath("~\\Archivos\\FotosPerfil") + "\\" + datos.Rows[0]["nomArchivo"].ToString());
        System.IO.File.Delete(SaveLocationAnt);
        user.IdUsr = int.Parse(datos.Rows[0]["idUsuario"].ToString());
        user.NomArch = "PerfilUsrDefault.png";
        logica.quitar_foto(user, datos.Rows[0]["nomUsuario"].ToString());
        datos.Rows[0]["nomArchivo"] = user.NomArch;
        Session["Sesion"] = datos;
        Response.Redirect("PerfilUsr.aspx");
    }
}