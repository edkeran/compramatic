using System;
using System.Data;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_AdministrarIdiomas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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