using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class Presentacion_AdministrarCategorias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        L_MostrTablaEmp log = new L_MostrTablaEmp();
        U_AuxQuejAdm res = log.pageLoad(Session["Sesion"], Session["sesion"], GridView1.Rows.Count);
        GridView1.UseAccessibleHeader = true;
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 27;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.adm.InnerText = compIdioma["adm"].ToString();
            this.cat.InnerText= compIdioma["cat"].ToString();
            this.cat2.InnerHtml= compIdioma["cat"].ToString()+" <small id='comp_our' runat='server'>" + compIdioma["comp_our"].ToString() + "</small>";
            this.all_cat.InnerText= compIdioma["all_cat"].ToString();
            this.reg_cat.InnerText= compIdioma["reg_cat"].ToString();
            this.Button2.Text = compIdioma["Button2"].ToString();
            this.Button1.Text = compIdioma["Button1"].ToString();
            this.vent_cat.InnerText = compIdioma["vent_cat"].ToString();
            this.Label1.Text= compIdioma["Label1"].ToString();
            this.NombreCategoria.Attributes.Remove("placeholder");
            this.NombreCategoria.Attributes.Add("placeholder", compIdioma["Nomb_Cat"].ToString());
            this.GridView2.Columns[1].HeaderText = compIdioma["GV2_Nom"].ToString();
            this.GridView1.Columns[0].HeaderText = compIdioma["GV2_Nom"].ToString();
            this.GridView1.Columns[1].HeaderText = compIdioma["GV1_N_EMP"].ToString();
            this.GridView1.Columns[2].HeaderText = compIdioma["GV1_N_VEN"].ToString();
            this.GridView1.Columns[3].HeaderText = compIdioma["GV1_T_VEN"].ToString();
            //this.bloq_perfi.InnerText = compIdioma["bloq_perfi"].ToString();
        }
        catch (Exception ex)
        {

        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + res.Redir + "');", true);
    }
  

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            L_AdministrarCategorias logi = new L_AdministrarCategorias();
            logi.btn1(IsValid, NombreCategoria.Text.ToString(), Session["sesion"]);
            GridView2.DataBind();
            NombreCategoria.Text = null;
        }
        catch (Exception ey) {}
    }

     

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        L_AdministrarCategorias log = new L_AdministrarCategorias();
        args.IsValid=log.ServerValidate(NombreCategoria.Text.ToString());
    }

   
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        L_AdministrarCategorias logi = new L_AdministrarCategorias();
        args.IsValid=logi.ServerValidate2(NombreCategoria.Text.ToString());
    }

   

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView2.SelectedRow;
        //
        // Obtengo el id de la entidad que se esta editando
        // en este caso de la entidad Person
        //
        String nom = Convert.ToString(GridView2.DataKeys[row.RowIndex].Value);
        NombreCategoria.Text = nom;
        Button1.Visible = false;
        Label5.Text = nom;
        Button2.Visible = true;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            L_AdministrarCategorias logi = new L_AdministrarCategorias();
            logi.btn2(IsValid, NombreCategoria.Text.ToString(), Label5.Text.ToString(), Session["sesion"]);
            Button2.Visible = false;
            Button1.Visible = true;
            NombreCategoria.Text = null;
            GridView2.DataBind();
        }
        catch (Exception eg) { }
    }

}