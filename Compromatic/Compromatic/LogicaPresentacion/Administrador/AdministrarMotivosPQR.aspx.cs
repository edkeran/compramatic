using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class Presentacion_AdministrarMotivosPQR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_AdminMotPqr logi = new L_AdminMotPqr();
        String resp=logi.page_load(Session["Sesion"], Session["sesion"]);
        String[] re = resp.Split('/');
        int num = int.Parse(re[1]);

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 34;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.adm.InnerText = compIdioma["adm"].ToString();
            this.mot.InnerText = compIdioma["mot"].ToString();
            this.mot_pqr.InnerText = compIdioma["mot_pqr"].ToString();
            this.Label1.Text = compIdioma["Label1"].ToString();
            this.NombreQueja.Attributes.Remove("placeHolder");
            this.NombreQueja.Attributes.Add("placeHolder", compIdioma["NombreQueja"].ToString());
            this.B_RegistrarMQueja.Text = compIdioma["B_RegistrarMQueja"].ToString();
            this.Button2.Text = compIdioma["Button2"].ToString();
            this.new_mot_rep.InnerText = compIdioma["new_mot_rep"].ToString();
            this.Label2.Text = compIdioma["Label2"].ToString();
            this.NombreReporte.Attributes.Remove("placeHolder");
            this.NombreReporte.Attributes.Add("placeHolder", compIdioma["NombreReporte"].ToString());
            this.B_RegistrarMReporte.Text = compIdioma["B_RegistrarMReporte"].ToString();
            this.Button1.Text = compIdioma["Button1"].ToString();
            this.mot_quej.InnerText = compIdioma["mot_quej"].ToString();
            this.reg_mot.InnerText = compIdioma["reg_mot"].ToString();
            this.rep_mot.InnerText = compIdioma["rep_mot"].ToString();
            this.GridView1.Columns[0].HeaderText = compIdioma["GV_ID"].ToString();
            this.GridView1.Columns[1].HeaderText = compIdioma["GV_NAME"].ToString();
            this.GridView2.Columns[0].HeaderText = compIdioma["GV_ID"].ToString();
            this.GridView2.Columns[1].HeaderText = compIdioma["GV_NAME"].ToString();
            //this.adm.InnerText = compIdioma["adm"].ToString();
        }
        catch (Exception ex)
        { }

        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scr", "redireccionar('" + re[0] + "');", true);
    }

    protected void B_RegistrarMQueja_Click(object sender, EventArgs e)
    {
        try
        {
            L_AdminMotPqr logi = new L_AdminMotPqr();
            logi.B_RegistrarMQueja_Click(IsValid, NombreQueja.Text.ToString(), Session["sesion"]);
            NombreQueja.Text = null;
            GridView2.DataBind();
        }
        catch(Exception et)
        {}
    }

    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //QUEJA
        L_AdminMotPqr logi = new L_AdminMotPqr();
        args.IsValid = logi.validarQueja(NombreQueja.Text.ToString());
    }
   
    protected void B_RegistrarMReporte_Click(object sender, EventArgs e)
    {
        try
        {
            L_AdminMotPqr logi = new L_AdminMotPqr();
            logi.registrarMReport(NombreReporte.Text.ToString(), Session["sesion"], IsValid);
            NombreReporte.Text = null;
            GridView1.DataBind();
        }
        catch(Exception eg) {}

    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        L_AdminMotPqr logi = new L_AdminMotPqr();
        args.IsValid=logi.serverValidate1(NombreReporte.Text.ToString());
    }
    
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView2.SelectedRow;
        int id = Convert.ToInt32(GridView2.DataKeys[row.RowIndex].Value);
        String nombre = Convert.ToString(row.Cells[1].Text);
        B_RegistrarMQueja.Visible = false;
        NomQueja.Text = id.ToString();
        NombreQueja.Text = nombre;
        Button2.Visible = true;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            L_AdminMotPqr logi = new L_AdminMotPqr();
            logi.BTN_2(IsValid, NombreQueja.Text.ToString(), NomQueja.Text, Session["sesion"]);
            B_RegistrarMQueja.Visible = true;
            Button2.Visible = false;
            NombreQueja.Text = null;
            GridView2.DataBind();
        }
        catch (Exception ef) {}
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
        String nombre = Convert.ToString(row.Cells[1].Text);
        B_RegistrarMReporte.Visible = false;
        Button1.Visible = true;
        nomReporte.Text = id.ToString();
        NombreReporte.Text = nombre;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            L_AdminMotPqr logi = new L_AdminMotPqr();
            logi.BTN_1(IsValid, NombreReporte.Text.ToString(), nomReporte.Text, Session["sesion"]);
            B_RegistrarMReporte.Visible = true;
            Button1.Visible = false;
            NombreReporte.Text = null;
            GridView1.DataBind();
        }catch(Exception ej) {}
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //FALTA EL BTN
        //
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 34;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            ((Button)e.Row.FindControl("Select")).Text = compIdioma["GV_BTN"].ToString();
        }
        catch (Exception ex)
        { }

    }
}