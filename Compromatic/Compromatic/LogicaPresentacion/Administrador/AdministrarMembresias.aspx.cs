using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using Logica;

public partial class Presentacion_AdministrarMembresias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_AdminMembre logi = new L_AdminMembre();
        String res=logi._Page_Load(Session["Sesion"], Session["sesion"]);
        String[] resp = res.Split('/');
        int num = int.Parse(resp[1]);

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 33;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {

           this.adm.InnerText = compIdioma["adm"].ToString();
           this.mem.InnerText = compIdioma["mem"].ToString();
           this.mem1.InnerHtml= compIdioma["mem"].ToString()+" <small id='compro' runat='server'> " + compIdioma["compro"].ToString() +"</small>";
           this.all_mem.InnerText= compIdioma["all_mem"].ToString();

           this.add_membership.InnerText = compIdioma["add_membership"].ToString();
           this.Label1.Text = compIdioma["Label1"].ToString();
           this.NombreMembresia.Attributes.Remove("placeholder");
           this.NombreMembresia.Attributes.Add("placeholder", compIdioma["NombreMembresia"].ToString());

           this.Label2.Text= compIdioma["Label2"].ToString();
           this.TB_Tiempo.Attributes.Remove("placeholder");
           this.TB_Tiempo.Attributes.Add("placeholder", compIdioma["TB_Tiempo"].ToString());

           this.Label3.Text = compIdioma["Label3"].ToString();
           this.TB_Valor.Attributes.Remove("placeholder");
           this.TB_Valor.Attributes.Add("placeholder", compIdioma["TB_Valor"].ToString());

           this.Button1.Text= compIdioma["Button1"].ToString();
           this.Button2.Text= compIdioma["Button2"].ToString();

           this.GridView2.Columns[1].HeaderText = compIdioma["GV2_Nom"].ToString();
           this.GridView2.Columns[0].HeaderText = compIdioma["GV2_Dur"].ToString();
           this.GridView2.Columns[2].HeaderText = compIdioma["GV2_Cost"].ToString();
        }
        catch (Exception ex)
        {}
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + resp[0] + "');", true);
    }
    
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        L_AdminMembre log = new L_AdminMembre();
        args.IsValid = log.CustomValidator1(NombreMembresia.Text.ToString());
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //INSERTAR UNA NUEVA MEMBRESIA AL PROYECTO
        try
        {
            L_AdminMembre logi = new L_AdminMembre();
            logi.btn1(IsValid, NombreMembresia.Text, TB_Tiempo.Text, TB_Valor.Text, Session["sesion"]);
            Button1.Visible = true;
            Button2.Visible = false;
            GridView2.DataBind();
            NombreMembresia.Text = null;
            TB_Tiempo.Text = null;
            TB_Valor.Text = null;
        }
        catch (Exception ex) {  }
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView2.SelectedRow;
        String nom = Convert.ToString(GridView2.DataKeys[row.RowIndex].Value);
        String duracion = Convert.ToString(row.Cells[1].Text);
        char [] dur={' ','M','e','s'};
        duracion = duracion.Trim(dur);
        
        String valor = Convert.ToString(row.Cells[2].Text);
        char[] val = {',','$','.'};
        valor = valor.Trim(val);
        valor = valor.Replace(",","");
        
        NombreMembresia.Text = nom;
        TB_Tiempo.Text = duracion;
        TB_Valor.Text = valor;
        Button1.Visible = false;
        Label5.Text = nom;
        Button2.Visible = true;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            L_AdminMembre logi = new L_AdminMembre();
            logi.btn2(IsValid, NombreMembresia.Text.ToString(), Label5.Text, TB_Tiempo.Text, TB_Valor.Text, Session["sesion"]);
            Button1.Visible = true;
            Button2.Visible = false;
            NombreMembresia.Text = null;
            TB_Tiempo.Text = null;
            TB_Valor.Text = null;
            GridView2.DataBind();
        }
        catch (Exception er) { }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        L_AdminMembre logi = new L_AdminMembre();
        args.IsValid=logi.CustomValidator2(NombreMembresia.Text, Label5.Text);
    }

    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 33;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            ((Button)e.Row.FindControl("Select")).Text= compIdioma["BTN_Modi"].ToString();
        }
        catch (Exception ex)
        { }
    }
}