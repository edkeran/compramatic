using System;
using System.Data;
using Datos;

namespace Logica
{
    public class L_AdministrarCategorias
    {
        public void btn1(bool IsValid,String NombreCategoria,object sesion)
        {
            if (IsValid)
            {
                String categoria;
                categoria = NombreCategoria;
                DDAOadministrador datos = new DDAOadministrador();
                datos.registrarCategoria(categoria, ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
                //GridView2.DataBind();
                //NombreCategoria.Text = null;
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public bool ServerValidate(String NombreCategoria)
        {
            String validacion;
            validacion = NombreCategoria.ToString();
            if (validacion.Length <= 20)
               return true;
            else
               return false;
        }

        public bool ServerValidate2(String NombreCategoria)
        {
            String validacion;
            validacion = NombreCategoria;
            DDAOadministrador datos = new DDAOadministrador();
            DataTable resul = datos.verificarCategoria(validacion);
            if (resul.Rows.Count > 0)
                return false;
            else
                return true;
        }

        public void btn2(bool IsValid,String NombreCategoria,String Label5,Object sesion)
        {
            if (IsValid)
            {
                String categoria;
                categoria = NombreCategoria;
                DDAOadministrador datos = new DDAOadministrador();
                datos.ModificarCategorias(categoria, Label5, ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
                ///Button2.Visible = false;
                ///Button1.Visible = true;
                //NombreCategoria.Text = null;
                //GridView2.DataBind();
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }
    }
}
