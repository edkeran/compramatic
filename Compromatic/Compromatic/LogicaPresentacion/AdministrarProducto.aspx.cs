using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class LogicaPresentacion_AdministrarProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DAOProducto DAO_Producto = new DAOProducto();
        if (!IsPostBack)
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
            if (int.Parse(Empresa.Rows[0]["estadoEmpresa"].ToString()) != 1)
            {
                Response.Redirect("PerfilEmpresa.aspx");
            }

            DataTable Productos = DAO_Producto.MostrarProducto(int.Parse(Empresa.Rows[0]["idEmpresa"].ToString()));
            Session["Productos"] = Productos;           
            Prueba1.DataSource = Productos;
            Prueba1.DataBind();

        }
        if (Session["IdProducto"] != null)
        {
            idProducto.Text = Session["IdProducto"].ToString();
        }
    }

    protected void BTN_AñadirTag_Click(object sender, EventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        if (idProducto.Text == "0")
        {
            Modal("Seleccione un producto");
            return;
        }
        IADTag IAD_Tag = new IADTag();
        IAD_Tag.RegistrarPalabra(TB_Tags.Text, int.Parse(idProducto.Text),Empresa.Rows[0]["nomEmpresa"].ToString());
        TB_Tags.Text = "";
        Response.Redirect(Request.Url.AbsoluteUri);

    }

    protected void BTN_Modificar_Click(object sender, EventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        IADProducto IAD_Producto = new IADProducto();
        if (idProducto.Text == "0")
        {
            Modal("Seleccione un producto");
            return;
        }
        IAD_Producto.ModificarProducto(TB_Nombre.Text, int.Parse(TB_Cantidad.Text), Double.Parse(TB_Precio.Text), TB_Descripcion.Text, int.Parse(DDL_Categoria.SelectedValue), int.Parse(idProducto.Text),Empresa.Rows[0]["nomEmpresa"].ToString());
        Modal("Modificacion Exitosa");
        Response.Redirect(Request.Url.AbsoluteUri);
    }

    public void Modal(String mensaje)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }
    protected void BTN_BorrarTag_Click(object sender, EventArgs e)
    {
        if (idProducto.Text == "0")
        {
            Modal("Seleccione un producto");
            return;
        }
        DataTable Empresa = (DataTable)Session["Sesion"];
        IADTag IAD_Tag = new IADTag();
        IAD_Tag.BorrarPalabra(int.Parse(DDL_Tags.SelectedValue),Empresa.Rows[0]["nomEmpresa"].ToString());
        Response.Redirect(Request.Url.AbsoluteUri);
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
        int limite = 5 - TablaImagenes.Items.Count;
        if (idProducto.Text == "0")
        {
            Modal("Seleccione un producto");
            return;
        }
        if (FU_FotoProducto.PostedFiles.Count > limite)
        {
            Modal("Limite de fotos excedido");
            return;
        }
        DataTable Empresa = (DataTable)Session["Sesion"];
        foreach (HttpPostedFile postedFile in FU_FotoProducto.PostedFiles)
        {

            String extension = System.IO.Path.GetExtension(FU_FotoProducto.PostedFile.FileName);
            String nombreArchivo = Empresa.Rows[0]["idEmpresa"].ToString() + RandomString(8) + extension;
            String saveLocation = (Server.MapPath("~\\Archivos\\FotosProductos") + "\\" + nombreArchivo);

            if (extension.Equals(".jpg") || extension.Equals(".jepg") || extension.Equals(".png") || extension.Equals(".JPG") || extension.Equals(".JEPG") || extension.Equals(".PNG"))
            {

                try
                {
                    postedFile.SaveAs(saveLocation);
                    IADProducto IAD_Producto = new IADProducto();
                    IAD_Producto.RegistrarFoto(int.Parse(idProducto.Text), nombreArchivo, "../Archivos/FotosProductos/" + nombreArchivo,Empresa.Rows[0]["nomEmpresa"].ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                Modal("Formato Incorrecto");
            }
        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void Prueba1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            DataTable Empresa = (DataTable)Session["Sesion"];
            IADProducto IAD_Producto = new IADProducto();
            DataTable Productos = (DataTable)Session["Productos"];
            IAD_Producto.BorrarProducto(int.Parse(Productos.Rows[e.Item.ItemIndex]["idProducto"].ToString()),Empresa.Rows[0]["nomEmpresa"].ToString());
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        if (e.CommandName == "Select")
        {
            DataTable Productos = (DataTable)Session["Productos"];
            idProducto.Text = Productos.Rows[e.Item.ItemIndex]["idProducto"].ToString();
            TB_Nombre.Text = Productos.Rows[e.Item.ItemIndex]["nomProducto"].ToString();
            TB_Cantidad.Text = Productos.Rows[e.Item.ItemIndex]["canProducto"].ToString();
            TB_Precio.Text = Productos.Rows[e.Item.ItemIndex]["precioProducto"].ToString();
            TB_Descripcion.Text = Productos.Rows[e.Item.ItemIndex]["desProducto"].ToString();
            DDL_Categoria.SelectedValue = Productos.Rows[e.Item.ItemIndex]["idCategoria"].ToString();
            TB_AlertaActual.Text=Productos.Rows[e.Item.ItemIndex]["bajoInventario"].ToString();
            Session["IdProducto"] = Productos.Rows[e.Item.ItemIndex]["idProducto"].ToString();
        }
    }
    protected void TablaImagenes_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DataTable Fotos = new DataTable();
        IADProducto IAD_Producto = new IADProducto();
        Fotos = IAD_Producto.MostrarFoto(int.Parse(idProducto.Text));
        String ruta = Fotos.Rows[e.Item.ItemIndex]["rutaArchivo"].ToString();
        ruta = (Server.MapPath("~\\Archivos\\FotosProductos") + "\\" + ruta);
        IAD_Producto.BorrarFoto(int.Parse(e.CommandArgument.ToString()));

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
        if (idProducto.Text == "0")
        {
            Modal("Seleccione un producto");
            return;
        }
        DAOProducto DAO_Producto = new DAOProducto();
        DAO_Producto.ModificarAlerta(int.Parse(idProducto.Text), int.Parse(TB_NuevaAlerta.Text),Empresa.Rows[0]["nomEmpresa"].ToString());
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}