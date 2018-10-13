using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using Logica;
using Utilitarios;

public partial class Presentacion_AumentarMembresia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            L_AumenMembre logi = new L_AumenMembre();
            U_AuxAumMemb resp = logi.page_load(IsPostBack, Session["Sesion"], Session["idEmpresa"]);
            TB_FechaInicio.Text = resp.TB_FechaInicio1;
            TB_FechaFinal.Text = resp.TB_FechaFinal1;
            TB_Precio.Text = resp.TB_Precio1;
            TB_Inicial.Text = resp.TB_Inicial1;
            TB_Final.Text = resp.TB_Final1;
            TB_Plan.Text = resp.TB_Plan1;

            //Seteando Idiomas
            L_Idioma idiot = new L_Idioma();
            Object sesidioma = Session["idiomases"];
            Int32 formulario = 23;
            Int32 idiom = Convert.ToInt32(sesidioma);
            Hashtable compIdioma = new Hashtable();
            idiot.mostraridioma(formulario, idiom, compIdioma);
            try
            {
                this.H1_Mem.InnerText= compIdioma["H1_Mem"].ToString();
                this.H4_Aum_Mem.InnerText= compIdioma["H4_Aum_Mem"].ToString();
                this.H4_Pln_Act.InnerText = compIdioma["H4_Pln_Act"].ToString();
                this.LB_Act_Date.InnerText = compIdioma["LB_Act_Date"].ToString();
                this.LB_End_Date.InnerText= compIdioma["LB_End_Date"].ToString();
                this.LB_Esta.InnerText= compIdioma["LB_Esta"].ToString();
                this.LB_Tip.InnerText= compIdioma["LB_Tip"].ToString();
                this.LB_New_In.InnerText= compIdioma["LB_New_In"].ToString();
                this.LB_New_En.InnerText= compIdioma["LB_New_En"].ToString();
                this.price.InnerText= compIdioma["price"].ToString();
                this.BTN_Comprar.Text= compIdioma["BTN_Comprar"].ToString();

                //this.respo.InnerText = compIdioma["respo"].ToString();
            }
            catch (Exception ex)
            { }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "scr", "redireccionar('" + resp.Redirecion + "');", true);
        }catch(Exception er)
        {
            //NO HAGO NADA
        }
    }

    protected void DDL_Memebresia_SelectedIndexChanged(object sender, EventArgs e)
    {
        L_AumenMembre logi = new L_AumenMembre();
        DateTime Fecha = DateTime.Now.Date;
        DataTable Membresia=logi.ddl_membresia_event(DDL_Memebresia.SelectedValue);
        TB_Precio.Text = "$" + Membresia.Rows[0]["Valor_mem"].ToString() + " COP";
        TB_FechaInicio.Text = Fecha.ToShortDateString();
        Fecha = Fecha.AddMonths(int.Parse(Membresia.Rows[0]["Tmpo_mem"].ToString()));
        TB_FechaFinal.Text = Fecha.ToShortDateString();
    }
    
    public void Modal(String mensaje)
    {
        String texto = "<script   src='https://code.jquery.com/jquery-2.2.4.min.js'> </script>" + "<script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>" + "<script>$('#modal-dialog').modal('show');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", texto);
        MensajeModal.Text = mensaje;
    }

    protected void BTN_Comprar_Click(object sender, EventArgs e)
    {
        L_AumenMembre logi = new L_AumenMembre();
        Modal(logi.btn_comprar(Session["Sesion"], TB_FechaInicio.Text, TB_FechaFinal.Text, DDL_Memebresia.SelectedValue, Session["idEmpresa"]));
    }
}