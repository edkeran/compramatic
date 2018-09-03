using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_VerProducto : System.Web.UI.Page
{
    //METODO DE LA PAGINA CUANDO CARGA
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_verProducto logica = new L_verProducto();
            UEUProducto resp = logica.page_load(IsPostBack, Session["VerProducto"], Session["Sesion"]);
            LB_NombreProducto.Text = resp.Nombre;
            LB_DescripcionProducto.Text = resp.Descripcion;
            LB_PrecioProducto.Text = resp.PrecioString;
            LB_NombreEmpresa.Text = resp.NomEmp;
            LB_CantidadProducto.Text = resp.Cantidad.ToString();
            LB_CategoriaProducto.Text = resp.NomCategoria;
            RP_FotosProductos.DataSource = resp.Fotos;
            RP_FotosProductos.DataBind();
        }
        catch(Exception ex)
        {}
    }

    /**
     * 
     * if (!IsPostBack)
        {

            if (Session["VerProducto"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                DataTable Fotos = new DataTable();
                DAOProducto DAO_Producto = new DAOProducto();

                DataTable producto = (DataTable)Session["VerProducto"];
                LB_NombreProducto.Text = producto.Rows[0]["nomProducto"].ToString();
                LB_DescripcionProducto.Text = producto.Rows[0]["desProducto"].ToString();
                LB_PrecioProducto.Text = "$" + producto.Rows[0]["precioProducto"].ToString();
                LB_NombreEmpresa.Text = producto.Rows[0]["nomEmpresa"].ToString();
                LB_CantidadProducto.Text = producto.Rows[0]["canProducto"].ToString();
                LB_CategoriaProducto.Text = producto.Rows[0]["nomCategoria"].ToString();
                Fotos = DAO_Producto.MostrarFotoProducto(int.Parse(producto.Rows[0]["idProducto"].ToString()));
                RP_FotosProductos.DataSource = Fotos;
                RP_FotosProductos.DataBind();
                
                if (Session["Sesion"] != null)
                {
                     DataTable user = (DataTable)Session["Sesion"];
                     if (user.Rows[0]["idTipo"].ToString() == "3")
                     {
                         DAOUsuario top = new DAOUsuario();
                         top.Top10(int.Parse(producto.Rows[0]["idProducto"].ToString()), int.Parse(user.Rows[0]["idUsuario"].ToString()),user.Rows[0]["nomUsuario"].ToString());
                     }
                }
            }
        }
     **/

    public void Modal(String mensaje)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }


    protected void BTN_ComprarProducto_Click(object sender, EventArgs e)
    {
        L_verProducto logic = new L_verProducto();
        UAuxVenta response=logic.BTN_ComprarProducto_Click(Session["Sesion"], Session["VerProducto"], TB_CantidadVenta.Text, LB_CantidadProducto.Text);
        Modal(response.Msg);
        BTN_Modal.Visible = response.Valido;
        BTN_Yes.Visible = response.BtnYes;
    }

    /**
     *if (Session["Sesion"] == null)
        {
            BTN_Modal.Visible = true;
            Modal("Tienes que iniciar sesion para comprar.");
        }
       
        else
        {
           
            DataTable user = (DataTable)Session["Sesion"];
            DataTable producto = (DataTable)Session["VerProducto"];
           
            
            if (TB_CantidadVenta.Text.Length==0)
            {
                Modal("Tienes que especificar la cantidad de productos a comprar.");
            }
            else if (user.Rows[0]["idTipo"].ToString() != "3")
            {
                Modal("Solo los clientes pueden hacer petición de compra.");
            }
            else if ((int.Parse(TB_CantidadVenta.Text)) > (int.Parse(LB_CantidadProducto.Text)))
            {
                Modal("Solicitaste una cantidad que excede nuestro límite de inventario, reduce tu cantidad de productos a comprar.");
            }

            else if (int.Parse(LB_CantidadProducto.Text) == 0)
            {
                Modal("El producto está agotado, intentalo después.");
            }
            else
            {
                EUVenta venta = new EUVenta();
                venta.IdUsr = int.Parse(user.Rows[0]["idUsuario"].ToString());
                int valor = int.Parse(TB_CantidadVenta.Text) * int.Parse(producto.Rows[0]["precioProducto"].ToString());
                BTN_Yes.Visible = true;
                Modal("Tu solicitud de compra ha sido enviada, por valor de $" + valor.ToString() + ", la empresa revisará los parámetros y decidirá aceptar o rechazar tu compra. Deseas confirmar esta compra?");
            }
        } 
     **/

    protected void BTN_Reportar_Click(object sender, EventArgs e)
    {
        L_verProducto logica = new L_verProducto();
        UAuxVenta resp= logica.BTN_Reportar_Click(Session["Sesion"], Session["VerProducto"], DDL_Reportes.SelectedValue);
        Modal(resp.Msg);
        BTN_Modal.Visible = resp.Valido;
    }

    /**
     *if (Session["Sesion"] == null)
        {
            BTN_Modal.Visible = true;
            Modal("Tienes que iniciar sesion para reportar este producto.");
        }
        else
        {
            DataTable validacion = (DataTable)Session["Sesion"];
            if (validacion.Rows[0]["idTipo"].ToString() != "3")
            {
                Modal("Solo los usuarios pueden reportar.");
                return;
            }
            DataTable user = (DataTable)Session["Sesion"];
            DataTable producto = (DataTable)Session["VerProducto"];
            DAOUsuario reporte = new DAOUsuario();
            int comprobar=reporte.ComprobarReporte(int.Parse(user.Rows[0]["idUsuario"].ToString()),int.Parse (producto.Rows[0]["idProducto"].ToString()));
            if (comprobar == 1)
            {
                Modal("Ya has reportado este producto con anterioridad.");
            }
            else
            {
                
                reporte.ReportarProducto(int.Parse(DDL_Reportes.SelectedValue), int.Parse(user.Rows[0]["idUsuario"].ToString()), int.Parse(producto.Rows[0]["idProducto"].ToString()),user.Rows[0]["nomUsuario"].ToString());
                reporte.Bloquear_producto(user.Rows[0]["nomUsuario"].ToString(), int.Parse(producto.Rows[0]["idProducto"].ToString()));
                Modal("Se ha enviado tu reporte a nuestro sistema.");


            }
        } 
     **/


    protected void BTN_Modal_Click(object sender, EventArgs e)
    {
        Response.Redirect("LoginUsr.aspx");
    }

    protected void BTN_Yes_Click(object sender, EventArgs e)
    {
        L_verProducto logica = new L_verProducto();
        logica.BTN_Yes_Click(Session["Sesion"], Session["VerProducto"], TB_CantidadVenta.Text);
    }

    /**
     * 
     *  DataTable user = (DataTable)Session["Sesion"];
        DataTable producto = (DataTable)Session["VerProducto"];
        EUVenta venta = new EUVenta();
        venta.IdUsr = int.Parse(user.Rows[0]["idUsuario"].ToString());
        venta.Cantidad = int.Parse(TB_CantidadVenta.Text);
        int valor = int.Parse(TB_CantidadVenta.Text) * int.Parse(producto.Rows[0]["precioProducto"].ToString());
        venta.Valor = valor;
        venta.IdProducto = int.Parse(producto.Rows[0]["idProducto"].ToString());
        venta.EstadoVenta = 1;
        DAOProducto compra = new DAOProducto();
        compra.CompraProducto(venta,user.Rows[0]["nomUsuario"].ToString());
     * 
     **/
    
    
}
 