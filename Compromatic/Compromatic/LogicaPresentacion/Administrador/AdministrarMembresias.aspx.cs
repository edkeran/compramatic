using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Presentacion_AdministrarMembresias : System.Web.UI.Page
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

    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        String validacion;
        validacion = NombreMembresia.Text.ToString();
        DAOadministrador datos = new DAOadministrador();
        DataTable resul = datos.verificarMembresia(validacion);
        if (resul.Rows.Count > 0)
            args.IsValid = false;
        else
            args.IsValid = true;  
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            DAOadministrador datos = new DAOadministrador();
            String nombre = NombreMembresia.Text.ToString();
            int tiempo = int.Parse(TB_Tiempo.Text.ToString());
            double valor = double.Parse(TB_Valor.Text.ToString());
            datos.registrarMembresia(nombre, tiempo, valor, ((DataTable)(Session["sesion"])).Rows[0]["nomUsuario"].ToString());
            Button1.Visible = true;
            Button2.Visible = false;
            GridView2.DataBind();
            NombreMembresia.Text = null;
            TB_Tiempo.Text = null;
            TB_Valor.Text = null;
        }
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
        if (IsValid)
        {
            String categoria;
            categoria = NombreMembresia.Text.ToString();
            DAOadministrador datos = new DAOadministrador();
            datos.ModificarMembresia(categoria, Label5.Text.ToString(), int.Parse(TB_Tiempo.Text.ToString()), Double.Parse(TB_Valor.Text.ToString()), ((DataTable)(Session["sesion"])).Rows[0]["nomUsuario"].ToString());
            Button1.Visible = true;
            Button2.Visible = false;
            NombreMembresia.Text = null;
            TB_Tiempo.Text = null;
            TB_Valor.Text = null;
            GridView2.DataBind();
        }
        
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        String validacion;
        validacion = NombreMembresia.Text.ToString();
        if (validacion.Equals(Label5.Text.ToString()))
        {
            args.IsValid = true;
        }
        else
        {
            DAOadministrador datos = new DAOadministrador();
            DataTable resul = datos.verificarMembresia(validacion);
            if (resul.Rows.Count >= 1)
                args.IsValid = false;
            else
                args.IsValid = true;
        }
         
    }
}