using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_AdministrarMotivosPQR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);

        if (Session["Sesion"] == null)
        {
            Response.Redirect("LoginUsr.aspx");
        }
        else
        {
            if (int.Parse(((DataTable)(Session["sesion"])).Rows[0]["idTipo"].ToString()) == 1)
            {

                int num = int.Parse(((DataTable)(Session["sesion"])).Rows[0]["idTipo"].ToString());

            }

            else
            {
                Response.Redirect("LoginUsr.aspx");
            }
        }
    }
    protected void B_RegistrarMQueja_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            String nom = NombreQueja.Text.ToString();
            DAOadministrador datos = new DAOadministrador();
            datos.registrarQueja(nom, ((DataTable)(Session["sesion"])).Rows[0]["nomUsuario"].ToString());
            NombreQueja.Text = null;
            GridView2.DataBind();
        }
    }
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //QUEJA
        String validacion;
        validacion = NombreQueja.Text.ToString();
        DAOadministrador datos = new DAOadministrador();
        DataTable resul = datos.verificarQueja(validacion);
        if (resul.Rows.Count > 0)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    protected void B_RegistrarMReporte_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            String nom = NombreReporte.Text.ToString();
            DAOadministrador datos = new DAOadministrador();
            datos.registrarReporte(nom, ((DataTable)(Session["sesion"])).Rows[0]["nomUsuario"].ToString());
            NombreReporte.Text = null;
            GridView1.DataBind();
        }
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        String validacion;
        validacion = NombreReporte.Text.ToString();
        DAOadministrador datos = new DAOadministrador();
        DataTable resul = datos.verificarReporte(validacion);
        if (resul.Rows.Count > 0)
            args.IsValid = false;
        else
            args.IsValid = true;
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
        if (IsValid)
        {
            DAOadministrador datos = new DAOadministrador();
            datos.ModificarMotivoQueja(NombreQueja.Text.ToString(), int.Parse(NomQueja.Text), ((DataTable)(Session["sesion"])).Rows[0]["nomUsuario"].ToString());
            B_RegistrarMQueja.Visible = true;
            Button2.Visible = false;
            NombreQueja.Text = null;
            GridView2.DataBind();
        }
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
        if (IsValid)
        {
           
            DAOadministrador datos = new DAOadministrador();
            datos.ModificarMotivoReporte(NombreReporte.Text.ToString(), int.Parse(nomReporte.Text), ((DataTable)(Session["sesion"])).Rows[0]["nomUsuario"].ToString());
            B_RegistrarMReporte.Visible = true;
            Button1.Visible = false;
            NombreReporte.Text = null;
            GridView1.DataBind();
        }
    }
}