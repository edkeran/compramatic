using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

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
        }
        catch (Exception ex)
        { }
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
        String term = Termin_Idioma.Text;
        String idioma = Nombre_Idioma.Text;
        L_Idioma logi = new L_Idioma();
        logi.insertar_idioma(idioma,term);
    }

    protected void DDL_Controles_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList cont = (DropDownList)sender;
        LB_Data.Text=cont.SelectedValue.ToString();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //Registro Traduccion
        L_Idioma logi = new L_Idioma();
        logi.insertar_traduccion(int.Parse(DDL_Idiomas.SelectedValue),int.Parse(DLL_forms.SelectedValue),TB_Trad.Text,DDL_Controles.SelectedItem.Text);
    }
}