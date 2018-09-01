using System;
using System.Data;
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
            DAOUsuario user = new DAOUsuario();
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
            aux = RP_PeticionesAceptadas;
            RP_PeticionesAceptadas.DataSource = res.Aceptadas;
            RP_PeticionesAceptadas.DataBind();
            RP_PeticionesRechazadas.DataSource = res.Rechazadas;
            RP_PeticionesRechazadas.DataBind();
            RP_ComprasHechas.DataSource = res.Hechas;
            RP_ComprasHechas.DataBind();

            String texto = "redireccionar('" + res.Redireccion + "')";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", texto, true);
        } catch (Exception ex)
        {
            //No Hago Nada
        }
    }

    /**
     * Codigo Orginal Page Load
     * 
     *  if (!IsPostBack)
        {
            if (Session["Sesion"] == null)
            {
                Response.Redirect("LoginUSr.aspx");
            }
            DataTable datos = (DataTable)Session["Sesion"];
            if (int.Parse(datos.Rows[0]["idTipo"].ToString()) != 3)
            {
                Response.Redirect("LoginUsr.aspx");
            }
            DataTable datouser = (DataTable)Session["Sesion"];
            EUsuario cliente = new EUsuario();
            cliente.IdUsr = int.Parse(datouser.Rows[0]["idUsuario"].ToString());


            DataTable peticiones = user.HistorialCompras(cliente, 1);
            RP_Peticiones.DataSource = peticiones;
            RP_Peticiones.DataBind();

            DataTable aceptadas = user.HistorialCompras(cliente, 2);
            RP_PeticionesAceptadas.DataSource = aceptadas;
            RP_PeticionesAceptadas.DataBind();

            DataTable rechazadas = user.HistorialCompras(cliente, 3);
            RP_PeticionesRechazadas.DataSource = rechazadas;
            RP_PeticionesRechazadas.DataBind();

            DataTable hechas = user.HistorialCompras(cliente, 4);
            RP_ComprasHechas.DataSource = hechas;
            RP_ComprasHechas.DataBind();
        }
     **/

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