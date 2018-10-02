using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using System.Drawing;
using Logica;
using Utilitarios;
using System.Web.UI;

public partial class Presentacion_AdministrarIdiomas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //FALTA LO DE REDIRECCIONAR SI NO  ES EL ROL INDICADO

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 35;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.adm.InnerText = compIdioma["adm"].ToString();
            this.idiom.InnerText = compIdioma["idiom"].ToString();
            this.idiom1.InnerHtml = compIdioma["idiom"].ToString() + " <small id='comp_our' runat='server'> " + compIdioma["comp_our"].ToString() + "</small>";
            this.all_cont.InnerText = compIdioma["all_cont"].ToString();
            this.LB_DDL1.Text = compIdioma["LB_DDL1"].ToString();
            this.LB_Form.Text = compIdioma["LB_Form"].ToString();
            this.LB_Contr.Text = compIdioma["LB_Contr"].ToString();
            this.LB_inf.Text = compIdioma["LB_inf"].ToString();
            this.LB_TB.Text = compIdioma["LB_TB"].ToString();
            this.Button2.Text = compIdioma["Button2"].ToString();
            this.reg_idm.InnerText = compIdioma["reg_idm"].ToString();
            this.Button1.Text = compIdioma["Button1"].ToString();
            this.Label2.Text= compIdioma["Label2"].ToString();
            this.Label1.Text = compIdioma["Label1"].ToString();
            this.TB_Trad.Attributes.Remove("placeHolder");
            this.TB_Trad.Attributes.Add("placeHolder", compIdioma["TB_Trad"].ToString());
            this.Nombre_Idioma.Attributes.Remove("placeHolder");
            this.Nombre_Idioma.Attributes.Add("placeHolder", compIdioma["Nombre_Idioma"].ToString());
            this.Termin_Idioma.Attributes.Remove("placeHolder");
            this.Termin_Idioma.Attributes.Add("placeHolder", compIdioma["Termin_Idioma"].ToString());
            this.BTN_chang.Text = compIdioma["BTN_chang"].ToString();
            this.H_Idiom.InnerText = compIdioma["H_Idiom"].ToString();
            this.GridView1.Columns[0].HeaderText = compIdioma["GV_Id"].ToString();
            this.GridView1.Columns[1].HeaderText = compIdioma["GV_Nom_Idiom"].ToString();
            this.GridView1.Columns[2].HeaderText = compIdioma["GV_Term"].ToString();
            this.GridView1.Columns[3].HeaderText = compIdioma["GV_Edit"].ToString();
            this.GridView1.Columns[4].HeaderText = compIdioma["GV_Del"].ToString();
        }
        catch (Exception ex)
        { }
        try
        {
            idiot.validar_postback(IsPostBack);
            GridView1.DataSource = idiot.traer_idioma_persistencia();
            GridView1.DataBind();
        }
        catch (Exception er)
        {

        }
    }

    protected void DLL_forms_SelectedIndexChanged(object sender, EventArgs e)
    {
        L_Idioma logi = new L_Idioma();
        DropDownList ddl = (DropDownList)sender;
        int id_form = int.Parse(ddl.SelectedValue.ToString());
        int id_language = int.Parse(DDL_Idiomas.SelectedValue.ToString());
        DataTable data=logi.obtner_controles(id_form,id_language);
        DDL_Controles.DataSource=data;
        DDL_Controles.DataTextField = "nom_control";
        DDL_Controles.DataValueField = "texto";
        DDL_Controles.DataBind();
        LB_Data.Text = DDL_Controles.SelectedValue.ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //METODO QUE ME REGISTRA EL IDIOMA
        UEUIdioma idiom= new UEUIdioma();
        idiom.Nombre_Idioma=Nombre_Idioma.Text;
        idiom.Terminacion=Termin_Idioma.Text;
        //String term = Termin_Idioma.Text;
        //String idioma = Nombre_Idioma.Text;
        L_Idioma logi = new L_Idioma();
        //logi.insertar_idioma(idioma,term);
        logi.insertar_idioma_persistencia(idiom);
        Response.Redirect("AdministrarIdiomas.aspx");
    }

    protected void DDL_Controles_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList cont = (DropDownList)sender;
        LB_Data.Text=cont.SelectedValue.ToString();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //Registro Traduccion
        try
        {
            L_Idioma logi = new L_Idioma();
            logi.insertar_traduccion(int.Parse(DDL_Idiomas.SelectedValue), int.Parse(DLL_forms.SelectedValue), TB_Trad.Text, DDL_Controles.SelectedItem.Text);
            this.LB_Succ.ForeColor = Color.Green;
            this.LB_Succ.Text = "Traduccion Correctamente Insertada";
        }
        catch (Exception err)
        {
            this.LB_Succ.ForeColor = Color.Red;
            this.LB_Succ.Text = err.Message.ToString();
        }
    }

    protected void BTN_Edit_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int command = int.Parse(btn.CommandArgument.ToString());
        BTN_chang.CommandArgument = command.ToString();
        BTN_chang.Visible = true;
        Button1.Visible = false;
        //OBTENER DATOS
        L_Idioma logi = new L_Idioma();
        UEUIdioma idim = logi.traer_datos(command);
        Termin_Idioma.Text = idim.Terminacion;
        Nombre_Idioma.Text = idim.Nombre_Idioma;
    }

    //BOTON DE ELIMINAR IDIOMA
    protected void BTN_Delet_Click(object sender, EventArgs e)
    {
        //METODO PARA ELIMINAR UN PRODUCTO
        Button btn = (Button)(sender);
        int id_idiom = int.Parse(btn.CommandArgument.ToString());
        L_Idioma logi = new L_Idioma();
        logi.eliminar_idioma(id_idiom);
        Response.Redirect("AdministrarIdiomas.aspx");
    }
      
    //BOTON DE CAMBIAR DATOS DEL IDIOMA
    protected void BTN_chang_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        UEUIdioma datos = new UEUIdioma();
        datos.Nombre_Idioma= Nombre_Idioma.Text;
        datos.Terminacion=Termin_Idioma.Text;
        datos.Id_Idioma =int.Parse(btn.CommandArgument);
        L_Idioma logi = new L_Idioma();
        logi.update_idiom(datos);
        Response.Redirect("AdministrarIdiomas.aspx");
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //SETEAR LOS DATOS 
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 35;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            ((Button)e.Row.FindControl("BTN_Edit")).Text= compIdioma["GV_Edit"].ToString();
            ((Button)e.Row.FindControl("BTN_Delet")).Text = compIdioma["GV_Del"].ToString();
        }
        catch (Exception ex)
        { }
    }
}