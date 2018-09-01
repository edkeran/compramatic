using System;
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

    //CODIGO ORGINAL

    //DAOProducto pdto = new DAOProducto();
    /**if (!IsPostBack)
    {
        if (Session["Sesion"] == null)
        {
            //PerfilUsr.Visible = false;
        }
        else
        {
            //<asp:ObjectDataSource runat="server" ID="OBSCategoria" SelectMethod="MostrarCategoria" TypeName="DAOProducto"></asp:ObjectDataSource>
            DataTable datos = (DataTable)Session["Sesion"];
            if (datos.Rows[0]["idTipo"].ToString() == "1" || datos.Rows[0]["idTipo"].ToString() == "3")
            {
                String rutaFoto = datos.Rows[0]["rutaArchivo"].ToString() + datos.Rows[0]["nomArchivo"].ToString();
                IMG_UsuarioBarraHome.ImageUrl = rutaFoto;
                LB_NombreUsuarioBarraHome.Text = datos.Rows[0]["nomUsuario"].ToString();
                Registro.Visible = false;
            }
            if (datos.Rows[0]["idTipo"].ToString() == "2")
            {
                String rutaFoto = datos.Rows[0]["rutaArchivo"].ToString() + datos.Rows[0]["nomArchivo"].ToString();
                IMG_UsuarioBarraHome.ImageUrl = rutaFoto;
                LB_NombreUsuarioBarraHome.Text = datos.Rows[0]["nomEmpresa"].ToString();
                Registro.Visible = false;
            }
        }
    }**/


    /**if (String.IsNullOrWhiteSpace(TB_Search.Text))
       {
           DAOProducto DAO_Producto = new DAOProducto();
           Session["Tienda"] = DAO_Producto.TodoProductos();
           Response.Redirect("Store.aspx");
       }
       DAOHome datos = new DAOHome();
       String palabra = TB_Search.Text.ToString();
       palabra = palabra.Replace(' ', '|');
       if(datos.Buscador(palabra).Rows.Count>0)
       {
           Session["Tienda"] = datos.Buscador(palabra);
           Response.Redirect("Store.aspx");
       }
       else
       {
           Modal("No se encontraron resultados");
       }**/


}
