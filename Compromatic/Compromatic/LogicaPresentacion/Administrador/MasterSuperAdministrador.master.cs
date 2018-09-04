using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using Utilitarios;

public partial class Presentacion_MasterSuperAdministrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_MasterAdmin logica = new L_MasterAdmin();
        U_AuxMasterAdmin response=logica.page_load(Session["sesion"]);
        Numero_noti.Text = response.Numero_noti1;
        cantidadAceptadas.Text = response.CantidadAceptadas;
        cantidadRechazadas.Text = response.CantidadRechazadas;
        cantidadPendientes.Text = response.CantidadPendientes;
        TotalAceptadas.Text = response.TotalAceptadas1;
        TotalRechazadas.Text = response.TotalRechazadas1;
        TotalPendientes.Text = response.TotalPendientes1;
        TotalSolicitudes.Text = response.TotalSolicitudes1;
        FotoPerfil.ImageUrl = response.FotoPerfil1;
        FotoPerfil2.ImageUrl = response.FotoPerfil1;
        NombrePerfil.Text = response.NombrePerfil1;
        NombrePerfil2.Text = response.NombrePerfil21;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + response.Redireccion + "');", true);
    }
    /**
     *  if(Session["Sesion"] ==null){
            Response.Redirect("LoginUsr.aspx");
        }
        else{
            int num = int.Parse(((DataTable)(Session["sesion"])).Rows[0]["idTipo"].ToString());
            if (int.Parse(((DataTable)(Session["sesion"])).Rows[0]["idTipo"].ToString()) == 1)
            {
                DAOadministrador user = new DAOadministrador();
                
                DataTable not=user.LlenarNotificacion();
                DataTable notAcep = user.LlenarNotificacionAceptadas();
                DataTable notRecha = user.LlenarNotificacionRechazada();
                if (not.Rows.Count == 0){
                    Numero_noti.Text = "0";
                }
                if(notAcep.Rows.Count == 0){
                    cantidadAceptadas.Text = "0";
                }
                if (notRecha.Rows.Count == 0)
                {
                    cantidadRechazadas.Text = "0";
                }
                else{

                    Numero_noti.Text = not.Rows[0]["Activas"].ToString();
                    cantidadAceptadas.Text = notAcep.Rows[0]["Activas"].ToString();
                    cantidadRechazadas.Text = notRecha.Rows[0]["Activas"].ToString();
                    cantidadPendientes.Text = not.Rows[0]["Activas"].ToString();
                    TotalAceptadas.Text = notAcep.Rows[0]["Activas"].ToString();
                    TotalRechazadas.Text = notRecha.Rows[0]["Activas"].ToString();
                    TotalPendientes.Text = not.Rows[0]["Activas"].ToString();
                }
                TotalSolicitudes.Text = ((int.Parse(notAcep.Rows[0]["Activas"].ToString())) + (int.Parse(notRecha.Rows[0]["Activas"].ToString())) + (int.Parse(not.Rows[0]["Activas"].ToString()))).ToString();

                String img=((DataTable)(Session["sesion"])).Rows[0]["rutaArchivo"].ToString() + ((DataTable)(Session["sesion"])).Rows[0]["nomArchivo"].ToString();
                FotoPerfil.ImageUrl = img;
                FotoPerfil2.ImageUrl = img;
                NombrePerfil.Text = ((DataTable)(Session["sesion"])).Rows[0]["nomUsuario"].ToString() +" "+ ((DataTable)(Session["sesion"])).Rows[0]["apeUsuario"].ToString();
                NombrePerfil2.Text = ((DataTable)(Session["sesion"])).Rows[0]["nomUsuario"].ToString();
            }
            else
            {
                Response.Redirect("LoginUsr.aspx");
            }
        }
     * */
    protected void ImageNotificacionPendientes_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SolicitudesPendientes.aspx");
    }


    protected void Salir_Click(object sender, EventArgs e)
    {
        Session["Sesion"] = null;
        Response.Redirect("LoginUsr.aspx");
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
    }
    protected void ImageNotificacionRechazadas_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SolicitudesRechazadas.aspx");
    }
    protected void ImageNotificacionAceptadas_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SolicitudesAceptadas.aspx");
    }
}
