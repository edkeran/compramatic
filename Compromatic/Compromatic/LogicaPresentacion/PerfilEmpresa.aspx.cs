using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_PerfilEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            L_PerfilEmpresa logica = new L_PerfilEmpresa();
            UEUEmpresa emp = logica.page_load(IsPostBack, Session["Sesion"]);
            String rutaFoto = emp.RutaArchivo + emp.NomArchivo;
            IMG_Foto.ImageUrl = rutaFoto;
            TB_Nit.Text = emp.Nit;
            TB_Nombre.Text = emp.Nombre;
            TB_Telefono.Text = emp.Numero;
            TB_Correo.Text = emp.Correo;
            TB_Direccion.Text = emp.Direccion;
            String texto = "redireccionar('" + emp.Redireccion + "');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scrpt", texto, true);
        }
        catch (Exception er)
        {
            //No Hago Nada
        }
    }

    /**
     * 
     * if (!IsPostBack)
        {

            if (Session["Sesion"] == null)
            {
                Response.Redirect("LoginUsr.aspx");
            }


            DataTable Empresa = (DataTable)Session["Sesion"];

            if (Empresa.Rows[0]["idTipo"].ToString() != "2")
            {
                Response.Redirect("LoginUsr.aspx");
            }
            else
            {
                String rutaFoto = Empresa.Rows[0]["rutaArchivo"].ToString() + Empresa.Rows[0]["nomArchivo"].ToString();
                IMG_Foto.ImageUrl = rutaFoto;

                TB_Nit.Text = Empresa.Rows[0]["nitEmpresa"].ToString();
                TB_Nombre.Text = Empresa.Rows[0]["nomEmpresa"].ToString();
                TB_Telefono.Text = Empresa.Rows[0]["telEmpresa"].ToString();
                TB_Correo.Text = Empresa.Rows[0]["correoEmpresa"].ToString();
                TB_Direccion.Text = Empresa.Rows[0]["dirEmpresa"].ToString();
            }

        }
     * 
     * 
     **/

    protected void CambiarContraseña(object sender, EventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        String contraseñaAntigua = Empresa.Rows[0]["passEmpresa"].ToString();
        L_PerfilEmpresa logica = new L_PerfilEmpresa();
        String mensage = logica.cambiarContraseña(TB_Contraseña.Text, TB_Contraseña2.Text, Empresa, contraseñaAntigua, TB_AntiguaContraseña.Text, TB_Nit.Text);
        Modal(mensage);
    }

    /**
     *if (TB_Contraseña.Text != TB_Contraseña2.Text)
        {
            Modal("Las Contraseñas no coinciden");
            return;
        }
        if (!TB_AntiguaContraseña.Text.Equals(contraseñaAntigua))
        {
            Modal("Contraseña Incorrecta");
            return;
        }
        IADEmpresa IAD_Empresa = new IADEmpresa();
        IAD_Empresa.CambiarContraseña(TB_Nit.Text, TB_Contraseña.Text,Empresa.Rows[0]["nomEmpresa"].ToString()); 
     **/

    protected void ModificarDatos(object sender, EventArgs e)
    {
        //DAOEmpresa envio = new DAOEmpresa();
        DataTable Empresa = (DataTable)Session["Sesion"];
        L_PerfilEmpresa logica = new L_PerfilEmpresa();
        U_aux_PerfilEmp res = logica.ModificarDatos(Empresa, TB_Correo.Text, TB_Nombre.Text, TB_Nit.Text, TB_Telefono.Text, TB_Direccion.Text, Request.RawUrl);
        Session["Sesion"] = res.Data;
        Modal(res.Mensage);
        String texto = "redireccionar('"+res.Response+"')";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scts", texto,true);
    }

    /**
     *if(Empresa.Rows[0]["correoEmpresa"].ToString()!=TB_Correo.Text)
        {
            if (envio.ExistenciaCorreo(TB_Correo.Text))
            {
                Modal("Correo Existente");
                return;
            }
        }
        EUEmpresa datos = new EUEmpresa();
        datos.Nombre = TB_Nombre.Text;
        datos.Nit = TB_Nit.Text;
        datos.Numero = TB_Telefono.Text;
        datos.Correo = TB_Correo.Text;
        datos.Direccion = TB_Direccion.Text;
        datos.Id = int.Parse(Empresa.Rows[0]["idEmpresa"].ToString());
        envio.ModificarEmpresa(datos,datos.Nombre);

        IADEmpresa IAD_Empresa = new IADEmpresa();
        Empresa = IAD_Empresa.Login(TB_Correo.Text, Empresa.Rows[0]["passEmpresa"].ToString());
        Session["Sesion"] = Empresa;
        Modal("Modificacion Exitosa");
        Response.Redirect(Request.RawUrl); 
     **/



    protected void BTN_SubirArchivo_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable Empresa = (DataTable)Session["Sesion"];
            DateTime Fecha = DateTime.Now.Date;
            L_PerfilEmpresa logica = new L_PerfilEmpresa();
            String extension = System.IO.Path.GetExtension(FU_Archivos.PostedFile.FileName);
            String nombreArchivo = TB_Nit.Text + Fecha.Day.ToString() + Fecha.Month.ToString() + GridView1.Rows.Count;
            String saveLocation = (Server.MapPath("~\\Archivos\\DocumentosEmpresa") + "\\" + nombreArchivo + extension);
            String response= logica.btn_SubirArchivo(GridView1.Rows.Count, Empresa, extension, nombreArchivo, saveLocation, TB_Nit.Text, FU_Archivos.PostedFile.InputStream);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", "<script>alert('"+response+"')</script>");
        }
        catch(Exception ex)
        {
            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }

    }

    /**
     * if (GridView1.Rows.Count >= 3)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", "<script>alert('Numero Excedido')</script>");
            return;
        }
        DateTime Fecha = DateTime.Now.Date;
        String extension = System.IO.Path.GetExtension(FU_Archivos.PostedFile.FileName);
        String nombreArchivo = TB_Nit.Text + Fecha.Day.ToString() + Fecha.Month.ToString() + GridView1.Rows.Count;
        String saveLocation = (Server.MapPath("~\\Archivos\\DocumentosEmpresa") + "\\" + nombreArchivo + extension);

        if (extension.Equals(".pdf"))
        {

            IADEmpresa IAD_Empresa = new IADEmpresa();
            IAD_Empresa.SubirArchivo(TB_Nit.Text, nombreArchivo, "../Archivos/DocumentosEmpresa/",Empresa.Rows[0]["nomEmpresa"].ToString());

            try
            {
                FU_Archivos.PostedFile.SaveAs(saveLocation);
            }
            catch (Exception exp)
            { throw exp; }
            Server.TransferRequest(Request.Url.AbsolutePath, false);

        }
        else
        {
            Modal("Formato Invalido");
            return;
        }
     **/


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        String nombreArchivo = GridView1.Rows[e.RowIndex].Cells[1].Text + ".pdf";
        String saveLocation = (Server.MapPath("~\\Archivos\\DocumentosEmpresa") + "\\" + nombreArchivo);
        try
        {
            System.IO.File.Delete(saveLocation);
        }
        catch (Exception es)
        {
            throw es;
        }
    }

    protected void BTN_CambiarFoto_Click(object sender, EventArgs e)
    {
        DataTable datos = (DataTable)Session["Sesion"];
        L_PerfilEmpresa logica = new L_PerfilEmpresa();
        String extensionAnterior = datos.Rows[0]["nomArchivo"].ToString();
        String[] aux = extensionAnterior.Split('.');
        extensionAnterior = "." + aux[1];
        String extension = System.IO.Path.GetExtension(FU_CambiarFoto.PostedFile.FileName);
        String nombreArchivo = TB_Nit.Text;
        String saveLocation = (Server.MapPath("~\\Archivos\\FotosPerfil") + "\\" + nombreArchivo + extension);
        String saveLocationAnterior = (Server.MapPath("~\\Archivos\\FotosPerfil") + "\\" + nombreArchivo + extensionAnterior);
        U_aux_PerfilEmp respuesta = logica.BTN_CambiarFoto_Click(extension, extensionAnterior, saveLocationAnterior, TB_Nit.Text, nombreArchivo, datos, saveLocation, FU_CambiarFoto.PostedFile.InputStream, Request.RawUrl);
        Session["Sesion"] =respuesta.Data;
        Modal(respuesta.Mensage);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scrt", "redireccionar('" + respuesta.Response+"')");
    }

    /**
     * 
     * if (extension.Equals(".jpg") || extension.Equals(".jepg") || extension.Equals(".png") || extension.Equals(".JPG") || extension.Equals(".JEPG") || extension.Equals(".PNG"))
        {

            if (!extensionAnterior.Equals(extension))
            {
                String saveLocationAnterior = (Server.MapPath("~\\Archivos\\FotosPerfil") + "\\" + nombreArchivo + extensionAnterior);
                System.IO.File.Delete(saveLocationAnterior);
                IADEmpresa IAD_Empresa = new IADEmpresa();
                IAD_Empresa.CambiarFoto(TB_Nit.Text, nombreArchivo + extension,datos.Rows[0]["nomEmpresa"].ToString());
            }
            else
            {
                System.IO.File.Delete(saveLocation);
            }

            try
            {

                FU_CambiarFoto.PostedFile.SaveAs(saveLocation);
                datos.Rows[0]["nomArchivo"] = nombreArchivo + extension;
                Session["Sesion"] = datos;
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        else
        {
            Modal("Formato Invalido");
            return;
        }
     **/

    public void Modal(String mensaje)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }
}