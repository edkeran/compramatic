﻿using System;
using System.Collections;
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
        String texto = "redireccionar('" + response.Response + "');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 1;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.titulo.Text= compIdioma["titulo"].ToString();
            this.perfil.InnerText = compIdioma["perfil"].ToString();
            this.Edit_Info.InnerText = compIdioma["Edit_Info"].ToString();
            this.mirar_perfil.InnerText = compIdioma["mirar_perfil"].ToString();
            this.camb_info.InnerText= compIdioma["camb_info"].ToString();
            this.camb_pass.InnerText = compIdioma["camb_pass"].ToString();
            this.peticiones.InnerText= compIdioma["peticiones"].ToString();
            this.ult_visit.InnerText= compIdioma["ult_visit"].ToString();
            this.bloq_perfi.InnerText= compIdioma["bloq_perfi"].ToString();
        }
        catch (Exception ex)
        {

        }
    }

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
        L_MasterBoardUsr logica = new L_MasterBoardUsr();
        DataTable data = (DataTable)Session["Sesion"];
        logica.cerrar_session_usuario(data);
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
