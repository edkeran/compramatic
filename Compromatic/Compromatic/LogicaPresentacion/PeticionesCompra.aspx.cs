using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_PeticionesCompra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_PeticionesCompra logic = new L_PeticionesCompra();
            U_aux_PeticionesCompra res = logic.page_load(IsPostBack, Session["Sesion"]);
            RP_Peticiones.DataSource = res.Producto;
            RP_Peticiones.DataBind();
            RP_EnProceso.DataSource = res.Producto2;
            RP_EnProceso.DataBind();
            RP_VentasRealizadas.DataSource = res.Producto3;
            RP_VentasRealizadas.DataBind();
            RP_Finalizadas.DataSource = res.Producto4;
            RP_Finalizadas.DataBind();

            //Seteando Idiomas
            L_Idioma idiot = new L_Idioma();
            Object sesidioma = Session["idiomases"];
            Int32 formulario = 21;
            Int32 idiom = Convert.ToInt32(sesidioma);
            Hashtable compIdioma = new Hashtable();
            idiot.mostraridioma(formulario, idiom, compIdioma);
            try
            {
                this.pet.InnerText= compIdioma["pet"].ToString();
                this.nom.InnerText= compIdioma["nom"].ToString();
                this.nomb.InnerText= compIdioma["nom"].ToString();
                this.celular.InnerText= compIdioma["celular"].ToString();
                this.mail.InnerText= compIdioma["mail"].ToString();
                this.dir.InnerText= compIdioma["dir"].ToString();
                this.cal.InnerText= compIdioma["cal"].ToString();
                this.prod.InnerText = compIdioma["prod"].ToString();
                this.stk.InnerText= compIdioma["stk"].ToString();
                this.val.InnerText= compIdioma["val"].ToString();
                this.fe.InnerText= compIdioma["fe"].ToString();
                this.comp_proc.InnerText= compIdioma["comp_proc"].ToString();
                this.telefo.InnerText= compIdioma["celular"].ToString();
                this.mai.InnerText= compIdioma["mail"].ToString();
                this.direc.InnerText= compIdioma["dir"].ToString();
                this.calif.InnerText= compIdioma["cal"].ToString();
                this.product.InnerText= compIdioma["prod"].ToString();
                this.valu.InnerText= compIdioma["val"].ToString();
                this.date.InnerText= compIdioma["fe"].ToString();
                this.calific.InnerText= compIdioma["calific"].ToString();
                this.nomber.InnerText= compIdioma["nom"].ToString();
                this.celu.InnerText= compIdioma["celular"].ToString();
                this.corr.InnerText= compIdioma["mail"].ToString();
                this.direcc.InnerText = compIdioma["dir"].ToString();
                this.cali.InnerText = compIdioma["cal"].ToString();
                this.prdcto.InnerText= compIdioma["prod"].ToString();
                this.valo.InnerText= compIdioma["val"].ToString();
                this.fha.InnerText= compIdioma["fe"].ToString();
                this.LB_Calif.InnerText= compIdioma["LB_Calif"].ToString();
                this.coment.InnerText= compIdioma["coment"].ToString();
                this.nbre.InnerText = compIdioma["nom"].ToString();
                this.tfn.InnerText= compIdioma["celular"].ToString();
                this.maii.InnerText = compIdioma["mail"].ToString();
                this.dirc.InnerText= compIdioma["dir"].ToString();
                this.calificar.InnerText = compIdioma["calific"].ToString();
                this.pcto.InnerText= compIdioma["prod"].ToString();
                this.valor.InnerText= compIdioma["val"].ToString();
                this.fecha.InnerText= compIdioma["fe"].ToString();
                this.vent_made.InnerText= compIdioma["vent_made"].ToString();
                //this.respo.InnerText = compIdioma["respo"].ToString();
            }
            catch (Exception ex)
            { }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + res.Redireccion + "');", true);
        }
        catch(Exception ex)
        {
            L_PeticionesCompra logic = new L_PeticionesCompra();
            logic.validarExcep(ex.Message);
        }
    }

    protected void RP_Peticiones_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        L_PeticionesCompra logica = new L_PeticionesCompra();
        String respesta=logica.RP_Peticiones_ItemCommand(Session["Sesion"],e.CommandArgument.ToString(),e.CommandName);
        String[] arr = respesta.Split(',');
        Modal(arr[0]);
        String texto = "redireccionar('"+arr[1]+"')";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "str", texto,true);

    }

    public void Modal(String mensaje)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }

    //FALTA ESTO

    protected void RP_EnProceso_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        L_PeticionesCompra logi = new L_PeticionesCompra();
        string res= logi.enProceso_ItemCommand(e.CommandName, e.CommandArgument.ToString(), Empresa);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "stg", "redireccionar('" + res + "');", true);
    }

    protected void RP_VentasRealizadas_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-calificar').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        L_PeticionesCompra logi = new L_PeticionesCompra();
        DataTable Venta = logi.RP_VentasReali(e.CommandArgument.ToString());
        LB_Usuario.Text = Venta.Rows[0]["idUsuario"].ToString();
        LB_Venta.Text = e.CommandArgument.ToString();
    }

    protected void BTN_Calificar_Click(object sender, EventArgs e)
    {
        DataTable Empresa = (DataTable)Session["Sesion"];
        //MIRAR VERSION ANTERIOR
        L_PeticionesCompra logi = new L_PeticionesCompra();
        logi.btn_Calificar(Empresa,TB_Calificacion.Text,TB_Comentario.Text,LB_Usuario.Text,LB_Venta.Text);
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}