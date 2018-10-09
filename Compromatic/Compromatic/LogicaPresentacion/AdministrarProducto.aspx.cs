using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class LogicaPresentacion_AdministrarProducto : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Object sesidioma = Session["idiomases"];
        try
        {
            L_AdministrarProducto logica = new L_AdministrarProducto();
            U_aux_AdminProd resp=logica.page_load(IsPostBack, Session["Sesion"], Session["IdProducto"]);
            Session["Productos"] = resp.Productos;
            Prueba1.DataSource = resp.Products;
            Prueba1.DataBind();
            idProducto.Text = resp.IdProducto.ToString();

            //Seteando Idiomas
            L_Idioma idiot = new L_Idioma();
            Int32 formulario = 13;
            Int32 idiom = Convert.ToInt32(sesidioma);
            Hashtable compIdioma = new Hashtable();
            idiot.mostraridioma(formulario, idiom, compIdioma);
            try
            {
                this.header.InnerText = compIdioma["header"].ToString();
                this.tbl_produ.InnerText = compIdioma["tbl_produ"].ToString();
                this.nom.InnerText = compIdioma["nom"].ToString();
                this.desc.InnerText = compIdioma["desc"].ToString();
                this.cant.InnerText = compIdioma["cant"].ToString();
                this.perc.InnerText = compIdioma["perc"].ToString();
                this.cate.InnerText = compIdioma["cate"].ToString();
                this.alert.InnerText = compIdioma["alert"].ToString();
                this.modif.InnerText = compIdioma["modif"].ToString();
                this.delete.InnerText = compIdioma["delete"].ToString();
                this.mod_data.InnerText = compIdioma["mod_data"].ToString();
                this.descri.InnerText = compIdioma["descri"].ToString();
                this.nombr.InnerText = compIdioma["nombr"].ToString();
                this.quant.InnerText = compIdioma["quant"].ToString();
                this.price.InnerText = compIdioma["price"].ToString();
                this.cat.InnerText = compIdioma["cat"].ToString();
                this.img.InnerText = compIdioma["img"].ToString();
                this.key_words.InnerText = compIdioma["key_words"].ToString();
                this.add.InnerText = compIdioma["add"].ToString();
                this.alr.InnerText = compIdioma["alr"].ToString();
                this.BTN_Modificar.Text= compIdioma["BTN_Modificar"].ToString();
                this.BTN_ModificarAlerta.Text= compIdioma["BTN_ModificarAlerta"].ToString();
                this.BTN_SubirFotos.Text = compIdioma["BTN_SubirFotos"].ToString();
            }
            catch (Exception ex)
            { }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scrti", "redireccionar('" + resp.Redir + "');", true);
        }
        catch(Exception ex)
        {
            //Significa que no se deben de recargar los controles
            String[] men = ex.Message.Split('/');
            idProducto.Text = men[0];
        }
    }


    protected void BTN_AñadirTag_Click(object sender, EventArgs e)
    {
       //BOTON PARA AÑADIR UN NUEVO TAG 
            L_AdministrarProducto logica = new L_AdministrarProducto();
            DataTable Empresa = (DataTable)Session["Sesion"];
            String response = logica.BTN_AñadirTag_Click(idProducto.Text, TB_Tags.Text, Empresa.Rows[0]["nomEmpresa"].ToString());
            Modal(response);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redir_Esp_admin('" + response + "');", true);
    }
   

    protected void BTN_Modificar_Click(object sender, EventArgs e)
    {
        L_AdministrarProducto logica = new L_AdministrarProducto();
        DataTable Empresa = (DataTable)Session["Sesion"];
        String response=logica.BTN_Modificar_Click(idProducto.Text, TB_Nombre.Text, TB_Cantidad.Text, TB_Precio.Text, TB_Descripcion.Text, DDL_Categoria.SelectedValue,Empresa);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redir_Esp_admin('" + response + "');", true);
    }
    

    public void Modal(String mensaje)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }

    protected void BTN_BorrarTag_Click(object sender, EventArgs e)
    {
        L_AdministrarProducto logica = new L_AdministrarProducto();
        String response=logica.BTN_BorrarTag_Click(idProducto.Text,Session["Sesion"], DDL_Tags.SelectedValue);
        Modal(response);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redir_Esp_admin('" + response + "');", true);
    }

    public String RandomString(int length)
    {
        Random random = new Random();
        const String chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

   
    protected void AgregarFotosProductos(object sender, EventArgs e)
    {
        L_AdministrarProducto logi = new L_AdministrarProducto();
        DataTable Empresa = (DataTable)Session["Sesion"];
        String extension = System.IO.Path.GetExtension(FU_FotoProducto.PostedFile.FileName);
        try
        {
            String nombreArchivo = Empresa.Rows[0]["idEmpresa"].ToString() + RandomString(8) + extension;
            String saveLocation = (Server.MapPath("~\\Archivos\\FotosProductos") + "\\" + nombreArchivo);
            IList<HttpPostedFile> files= FU_FotoProducto.PostedFiles;
            IList<Stream> pictures = new List<Stream>();
            pictures.Add(files.ElementAt(0).InputStream);
            try
            {
                pictures.Add(files.ElementAt(1).InputStream);
            }catch(Exception et) { }
            try
            {
                pictures.Add(files.ElementAt(2).InputStream);
            }catch(Exception ey) { }
            String response= logi.AgregarFotosProd(TablaImagenes.Items.Count, idProducto.Text,
            FU_FotoProducto.PostedFiles.Count, Session["Sesion"], saveLocation, pictures, extension, nombreArchivo);
            String[] data=response.Split('/');
            Modal(data[0]);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + data[1] + "');", true);
        }
        catch(Exception err)
        {
            throw err;
        }
    }

   

    protected void Prueba1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            L_AdministrarProducto logica = new L_AdministrarProducto();
            DataTable Empresa = (DataTable)Session["Sesion"];
            DataTable Productos = (DataTable)Session["Productos"];
            UEUProducto resp = logica.Prueba1_ItemCommand(e.CommandName, Empresa, Productos, e.Item.ItemIndex);
            idProducto.Text =resp.Id.ToString();
            TB_Nombre.Text = resp.Nombre;
            TB_Cantidad.Text = resp.Cantidad.ToString();
            TB_Precio.Text = resp.Precio.ToString();
            TB_Descripcion.Text = resp.Descripcion;
            DDL_Categoria.SelectedValue = resp.Categoria.ToString();
            TB_AlertaActual.Text = resp.BajoInventario.ToString();
            Session["IdProducto"] = resp.Id;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "stru", "redir_Esp_admin('" + resp + "');", true);
        }catch(Exception ex)
        {
            L_AdministrarProducto logica = new L_AdministrarProducto();
            logica.validarException(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "stru", "redir_Esp_admin('0');", true);
        }
    }
    
    protected void TablaImagenes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DataTable Fotos = new DataTable();
        L_AdministrarProducto logica = new L_AdministrarProducto();
        Fotos = logica.MostrarFoto(int.Parse(idProducto.Text));
        String ruta = Fotos.Rows[e.Item.ItemIndex]["rutaArchivo"].ToString();
        ruta = (Server.MapPath("~\\Archivos\\FotosProductos") + "\\" + ruta);
        logica.BorrarFoto(int.Parse(e.CommandArgument.ToString()));

        try
        {
            System.IO.File.Delete(ruta);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        Response.Redirect(Request.Url.AbsoluteUri);
    }


    protected void BTN_ModificarAlerta_Click(object sender, EventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        L_AdministrarProducto logica = new L_AdministrarProducto();
        String response=logica.BTN_ModificarAlerta_Click(Empresa, idProducto.Text, TB_NuevaAlerta.Text);
        Modal(response);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redir_Esp_admin('" + response + "');", true);
    }

    protected void RptUno_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Object sesidioma = Session["idiomases"];
        Button btn=(Button)e.Item.FindControl("BTN_delete_img");
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Int32 formulario = 13;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            btn.Text = compIdioma["BTN_delete_img"].ToString();

        }
        catch (Exception ex)
        { throw ex; }
       
    }

    protected void RptDos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Object sesidioma = Session["idiomases"];
        Button btn = (Button)e.Item.FindControl("BTN_select");
        Button btn1 = (Button)e.Item.FindControl("BTN_del");
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Int32 formulario = 13;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            btn.Text = compIdioma["BTN_select"].ToString();
            btn1.Text= compIdioma["BTN_del"].ToString();
        }
        catch (Exception ex)
        { throw ex; }

    }
}