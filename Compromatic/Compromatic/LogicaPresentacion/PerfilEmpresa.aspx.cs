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
        this.perfil.InnerText = "Profile";
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

    protected void CambiarContraseña(object sender, EventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        String contraseñaAntigua = Empresa.Rows[0]["passEmpresa"].ToString();
        L_PerfilEmpresa logica = new L_PerfilEmpresa();
        String mensage = logica.cambiarContraseña(TB_Contraseña.Text, TB_Contraseña2.Text, Empresa, contraseñaAntigua, TB_AntiguaContraseña.Text, TB_Nit.Text);
        Modal(mensage);
    }

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
    
    public void Modal(String mensaje)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }
}