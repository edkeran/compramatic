using System;
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
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "redireccionar('" + res.Redir + "');", true);
    }
    /**
     * 
     *  if (Session["Sesion"] == null)
        {
            Response.Redirect("LoginUsr.aspx");
        }
        else
        {
            if (int.Parse(((DataTable)(Session["sesion"])).Rows[0]["idTipo"].ToString()) == 1)
            {
                if (GridView1.Rows.Count > 0)
                {
                    GridView1.UseAccessibleHeader = true;
                    GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                int num = int.Parse(((DataTable)(Session["sesion"])).Rows[0]["idTipo"].ToString());

            }

            else
            {
                Response.Redirect("LoginUsr.aspx");
            }
        }
     **/

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

      /**if (IsValid)
        {
            String categoria;
            categoria = NombreCategoria.Text.ToString();
            DAOadministrador datos = new DAOadministrador();
            datos.registrarCategoria(categoria,((DataTable)(Session["sesion"])).Rows[0]["nomUsuario"].ToString());
            GridView2.DataBind();
            NombreCategoria.Text = null;
        }
     **/

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        L_AdministrarCategorias log = new L_AdministrarCategorias();
        args.IsValid=log.ServerValidate(NombreCategoria.Text.ToString());
    }

    /**
     *  String validacion;
        validacion = NombreCategoria.Text.ToString();
        if (validacion.Length <= 20)
            args.IsValid = true;
        else
            args.IsValid = false;     
     **/

    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        L_AdministrarCategorias logi = new L_AdministrarCategorias();
        args.IsValid=logi.ServerValidate2(NombreCategoria.Text.ToString());
    }

    /**
     * String validacion;
        validacion = NombreCategoria.Text.ToString();
        DAOadministrador datos = new DAOadministrador();
        DataTable resul = datos.verificarCategoria(validacion);
        if (resul.Rows.Count > 0)
            args.IsValid = false;
        else
            args.IsValid = true; 
     **/

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
    /**
     *  if (IsValid)
        {
            String categoria;
            categoria = NombreCategoria.Text.ToString();
            DAOadministrador datos = new DAOadministrador();
            datos.ModificarCategorias(categoria, Label5.Text.ToString(), ((DataTable)(Session["sesion"])).Rows[0]["nomUsuario"].ToString());
            Button2.Visible = false;
            Button1.Visible = true;
            NombreCategoria.Text = null;
            GridView2.DataBind();
        }
     **/

}