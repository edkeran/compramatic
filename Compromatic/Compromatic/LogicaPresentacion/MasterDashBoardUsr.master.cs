using System;
using System.Data;
using Logica;
using Utilitarios;

public partial class Presentacion_MasterDashBoardUsr : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_MasterBoardUsr logica = new L_MasterBoardUsr();
        U_aux_master_Usr response = logica.page_load(Session["Sesion"]);
        String rutaFoto = response.User.RutaArch + response.User.NomArch;
            DataTable datos = (DataTable)Session["Sesion"];
       
            IMG_FotoPerfilSideBar.ImageUrl = rutaFoto;
            LB_NombreSideBar.Text = response.User.NomUsr;
            LB_ApellidoSideBar.Text = response.User.ApelUsr;
        
            IMG_PerfilHeatherNR.ImageUrl = rutaFoto;
            LB_NombreHeatherNR.Text = response.User.NomUsr;

        //Redireccion Segun Sea El Caso
        String texto ="redireccionar('"+response.Response+"');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);


    }
    /**
     * if (Session["Sesion"] == null)
        {
            Response.Redirect("LoginUsr.aspx");
        }
        else
        {
            DataTable datos = (DataTable)Session["Sesion"];
            //String rutaFoto = datos.Rows[0]["rutaArchivo"].ToString() + datos.Rows[0]["nomArchivo"].ToString();
            if (int.Parse(datos.Rows[0]["idTipo"].ToString()) != 3)
            {
                Response.Redirect("LoginUsr.aspx");
            }


            //sideBar
            IMG_FotoPerfilSideBar.ImageUrl = rutaFoto;
            LB_NombreSideBar.Text = response.User.NomUsr;
            LB_ApellidoSideBar.Text = response.User.ApelUsr;

            //End sideBar

            //Heather Navigation Right
            IMG_PerfilHeatherNR.ImageUrl = rutaFoto;
            LB_NombreHeatherNR.Text = response.User.NomUsr;
            ////Heather Navigation Right
        }
     * */


    protected void BtnSi_Click(object sender, EventArgs e)
    {
        DataTable datos = (DataTable)Session["Sesion"];
        UEUsuario user = new UEUsuario();
        L_MasterBoardUsr logica = new L_MasterBoardUsr();
        //DAOUsuario bloqueo = new DAOUsuario();
        user.IdUsr = int.Parse(datos.Rows[0]["idUsuario"].ToString());
        logica.btnSi_Click(user, 0, datos.Rows[0]["nomUsuario"].ToString());
        //bloqueo.BloqueoUser(user,0,datos.Rows[0]["nomUsuario"].ToString());
        Session["Sesion"] = null;
        Response.Redirect("LoginUsr.aspx");
    }

    protected void BtnLogOut_Click(object sender, EventArgs e)
    {
        Session["Sesion"] = null;
        Response.Redirect("AboutUs.aspx");
    }

    protected void BTN_Enviar_Click(object sender, EventArgs e)
    {
        DataTable datos = (DataTable)Session["Sesion"];
        L_MasterBoardUsr logica = new L_MasterBoardUsr();
        UEUPqr pqr = new UEUPqr();
        //DAOPqr queja = new DAOPqr();
        pqr.Descripcion = TB_Descripcion.Text;
        pqr.IdCliente = int.Parse(datos.Rows[0]["idUsuario"].ToString());
        logica.btn_enviar(pqr, datos.Rows[0]["nomUsuario"].ToString());
        //queja.QuejaUsr(pqr,datos.Rows[0]["nomUsuario"].ToString());
        TB_Descripcion.Text = "";

    }

  
}
