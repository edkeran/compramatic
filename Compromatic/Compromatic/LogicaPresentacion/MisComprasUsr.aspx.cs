using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_MisComprasUsr : System.Web.UI.Page
{
    Repeater aux = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_MisComprasUsr logica = new L_MisComprasUsr();
            U_aux_MisComprasUsr orig = new U_aux_MisComprasUsr();
            U_aux_MisComprasUsr res = logica.page_load(Session["Sesion"], IsPostBack);
            orig.Peticiones = (DataTable)RP_Peticiones.DataSource;
            orig.Aceptadas = (DataTable)RP_PeticionesAceptadas.DataSource;
            orig.Rechazadas = (DataTable)RP_PeticionesRechazadas.DataSource;
            orig.Hechas = (DataTable)RP_ComprasHechas.DataSource;
            res = logica.Caso_nulos(orig, res);
            RP_Peticiones.DataSource = res.Peticiones;
            RP_Peticiones.DataBind();
            RP_PeticionesRechazadas.DataSource = res.Rechazadas;
            RP_PeticionesRechazadas.DataBind();
            RP_ComprasHechas.DataSource = res.Hechas;
            RP_ComprasHechas.DataBind();

            //Seteando Idiomas
            L_Idioma idiot = new L_Idioma();
            Object sesidioma = Session["idiomases"];
            Int32 formulario = 5;
            Int32 idiom = Convert.ToInt32(sesidioma);
            Hashtable compIdioma = new Hashtable();
            idiot.mostraridioma(formulario, idiom, compIdioma);
            try
            {
                this.ti_pet.InnerText = compIdioma["ti_pet"].ToString();
                this.pet_acept.InnerText = compIdioma["pet_acept"].ToString();
                this.N_ven.InnerText = compIdioma["N_ven"].ToString();
                this.fech.InnerText = compIdioma["fech"].ToString();
                this.quantity.InnerText = compIdioma["quantity"].ToString();
                this.value.InnerText = compIdioma["value"].ToString();
                this.emp_nom.InnerText = compIdioma["emp_nom"].ToString();
                this.nom_product.InnerText = compIdioma["nom_product"].ToString();
                this.num_ven.InnerText = compIdioma["num_ven"].ToString();
                this.fecha.InnerText = compIdioma["fecha"].ToString();
                this.cant.InnerText = compIdioma["cant"].ToString();
                this.val.InnerText = compIdioma["val"].ToString();
                this.emp_nomb.InnerText = compIdioma["emp_nomb"].ToString();
                this.nom_produ.InnerText = compIdioma["nom_produ"].ToString();
                this.conf_recib.InnerText = compIdioma["conf_recib"].ToString();
                this.rech_pet.InnerText = compIdioma["rech_pet"].ToString();
                this.nume_venta.InnerText = compIdioma["nume_venta"].ToString();
                this.date.InnerText = compIdioma["date"].ToString();
                this.cantidad.InnerText = compIdioma["cantidad"].ToString();
                this.valor.InnerText = compIdioma["valor"].ToString();
                this.nom_empre.InnerText = compIdioma["nom_empre"].ToString();
                this.nom_prod.InnerText = compIdioma["nom_prod"].ToString();
                this.comp_done.InnerText = compIdioma["comp_done"].ToString();
                this.n_vnt.InnerText = compIdioma["n_vnt"].ToString();
                this.pet_date.InnerText = compIdioma["pet_date"].ToString();
                this.entre_date.InnerText = compIdioma["entre_date"].ToString();
                this.quan.InnerText = compIdioma["quan"].ToString();
                this.valu.InnerText = compIdioma["valu"].ToString();
                this.nombe_producto.InnerText = compIdioma["nombe_producto"].ToString();
                DataColumn colum = new DataColumn();
                colum.DefaultValue = compIdioma["LB_Califi"].ToString();
                colum.ColumnName = "LB_Califi";
                res.Aceptadas.Columns.Add(colum);
                colum = new DataColumn();
                colum.ColumnName = "LB_Comment";
                colum.DefaultValue = compIdioma["LB_Comment"].ToString();
                res.Aceptadas.Columns.Add(colum);
                colum = new DataColumn();
                colum.ColumnName = "BTN_Confirmar";
                colum.DefaultValue = compIdioma["BTN_Confirmar"].ToString();
                res.Aceptadas.Columns.Add(colum);
                this.BTN_Historial.Text= compIdioma["BTN_Historial"].ToString();
            }
            catch (Exception ex)
            {

            }
            aux = RP_PeticionesAceptadas;
            RP_PeticionesAceptadas.DataSource = res.Aceptadas;
            RP_PeticionesAceptadas.DataBind();
            String texto = "redireccionar('" + res.Redireccion + "')";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", texto, true);
        } catch (Exception ex)
        {
            //No Hago Nada
        }
    }

    protected void BTN_Historial_Click(object sender, EventArgs e)
    {
        Response.Redirect("HistorialUsr.aspx");
    }

    protected void RP_PeticionesAceptadas_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        L_MisComprasUsr logica = new L_MisComprasUsr();
        TextBox t2 = (TextBox)RP_PeticionesAceptadas.Items[e.Item.ItemIndex].FindControl("TB_Comentario");
        TextBox t1 = (TextBox)RP_PeticionesAceptadas.Items[e.Item.ItemIndex].FindControl("TB_Calificacion");
        U_aux_MisComprasUsr res= logica.RP_PeticionesAceptadas_ItemCommand(e.CommandName, t2.Text,Session["Sesion"],t1.Text, e.CommandArgument.ToString(), Request.Url.AbsoluteUri);
        Modal(res.Mensaje,res.Redireccion);
    }

    public void Modal(String mensaje,String page)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');var mod=$('#modal-dialog');$('#myBtn').click(function(){$('#modal-dialog').modal('hide'); redireccionar('" + page + "')});</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }
}