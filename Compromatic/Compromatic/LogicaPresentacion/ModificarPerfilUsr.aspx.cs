using System;
using System.Data;
using System.Web.UI;
using Utilitarios;
using Logica;

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
        String texto = "redireccionar('" + user.Redireccion + "');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scrt", texto, true);
    }

    /**
     *if (Session["Sesion"] == null)
        {
            Response.Redirect("LoginUsr.aspx");
        }
        DataTable datos = (DataTable)Session["Sesion"];
        if (datos.Rows[0]["idTipo"].ToString() != "3")
        {
            Response.Redirect("LoginUsr.aspx");
        }
        else
        {
            IMG_FotoPerfil.ImageUrl = datos.Rows[0]["rutaArchivo"].ToString() + datos.Rows[0]["nomArchivo"].ToString();
            LB_Nombre.Text = datos.Rows[0]["nomUsuario"].ToString();
            LB_Apellido.Text = datos.Rows[0]["apeUsuario"].ToString();
            LB_Telefono.Text = datos.Rows[0]["telUsuario"].ToString();
            LB_Cc.Text = datos.Rows[0]["ccUsuario"].ToString();
            LB_Correo.Text = datos.Rows[0]["correoUsuario"].ToString();
            LB_Direccion.Text = datos.Rows[0]["dirUsuario"].ToString();
        } 
     **/

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

    /**
     * CODIGO DE LA MODIFICACION ORIGINAL
     *  if ((envio.ComprobarCorreo(TB_Correo.Text)) == 1)
        {
            Modal("El correo ya existe, registra uno diferente.");
        }
        else
        {
            //Nombre
            if (TB_Nombre.Text.Length != 0)
            {
                cliente.NomUsr = TB_Nombre.Text;
                datos.Rows[0]["nomUsuario"] = TB_Nombre.Text;
            }
            if (TB_Nombre.Text.Length == 0)
            {
                cliente.NomUsr = datos.Rows[0]["nomUsuario"].ToString();
            }
            //Apellido
            if (TB_Apellido.Text.Length != 0)
            {
                cliente.ApelUsr = TB_Apellido.Text;
                datos.Rows[0]["apeUsuario"] = TB_Apellido.Text;
            }
            if (TB_Apellido.Text.Length == 0)
            {
                cliente.ApelUsr = datos.Rows[0]["apeUsuario"].ToString();
            }
            //Telefono
            if (TB_Telefono.Text.Length != 0)
            {
                cliente.TelUsr = TB_Telefono.Text;
                datos.Rows[0]["telUsuario"] = TB_Telefono.Text;
            }
            if (TB_Telefono.Text.Length == 0)
            {
                cliente.TelUsr = datos.Rows[0]["telUsuario"].ToString();
            }
            //Cc
            if (TB_Cc.Text.Length != 0)
            {
                cliente.CcUsr = TB_Cc.Text;
                datos.Rows[0]["ccUsuario"] = TB_Cc.Text;
            }
            if (TB_Cc.Text.Length == 0)
            {
                cliente.CcUsr = datos.Rows[0]["ccUsuario"].ToString();
            }
            //Correo
            if (TB_Correo.Text.Length != 0)
            {
                cliente.CorreoUsr = TB_Correo.Text;
                datos.Rows[0]["correoUsuario"] = TB_Correo.Text;
            }
            if (TB_Correo.Text.Length == 0)
            {
                cliente.CorreoUsr = datos.Rows[0]["correoUsuario"].ToString();
            }
            //Direccion
            if (TB_Direccion.Text.Length != 0)
            {
                cliente.DirUsr = TB_Direccion.Text;
                datos.Rows[0]["dirUsuario"] = TB_Direccion.Text;
            }
            if (TB_Direccion.Text.Length == 0)
            {
                cliente.DirUsr = datos.Rows[0]["dirUsuario"].ToString();
            }
            DAOUsuario modificar = new DAOUsuario();
            modificar.ModificarInf(cliente,datos.Rows[0]["nomUsuario"].ToString());
            Session["Sesion"] = datos;
            Modal("Modificacion Exitosa");
            Response.Redirect("PerfilUsr.aspx");
        }
     * */

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
        U_Modificar_Pfi_Usr res = logic.cambiar_foto(saveLocation,FU_CambiarFoto.PostedFile,extension,datos,nombreArchivo, SaveLocationAnt);
        //Session["Sesion"] = res.Datos;
        Modal(res.Mensage, res.Pagina_redir);
    }

    /**
     * CODIGO ORIGINAL
     * if (extension.Equals(".jpg") || extension.Equals(".jepg") || extension.Equals(".png") || extension.Equals(".JPG") || extension.Equals(".JEPG") || extension.Equals(".PNG"))
        {
            String nomArchivoAnt = datos.Rows[0]["nomArchivo"].ToString();
            String[] aux = nomArchivoAnt.Split('.');
            nomArchivoAnt = aux[0];
            if (nomArchivoAnt == datos.Rows[0]["idUsuario"].ToString())
            {
               
                System.IO.File.Delete(SaveLocationAnt);
            }

            try
            {
                FU_CambiarFoto.PostedFile.SaveAs(saveLocation);
                DAOUsuario foto = new DAOUsuario();
                EUsuario user = new EUsuario();
                user.IdUsr = int.Parse(datos.Rows[0]["idUsuario"].ToString());
                user.NomArch = nombreArchivo + extension;
                foto.CambiarFoto(user,datos.Rows[0]["nomUsuario"].ToString());
                datos.Rows[0]["nomArchivo"] = nombreArchivo + extension;
                Session["Sesion"] = datos;
                Response.Redirect("PerfilUsr.aspx");
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        else
        {
            Modal("Formato Invalido","0");
            return;
        }
     **/


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