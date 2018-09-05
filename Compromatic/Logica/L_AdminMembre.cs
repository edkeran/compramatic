using System;
using System.Collections.Generic;
using System.Data;
using Utilitarios;
using Datos;

namespace Logica
{
    public class L_AdminMembre
    {
        public String  _Page_Load(Object Session,Object sesion)
        {
            if (Session == null)
            {
                return "LoginUsr.aspx/0";
                //Response.Redirect("LoginUsr.aspx");
            }
            else
            {
                if (int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString()) == 1)
                {

                    int num = int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString());
                    return "0/" + num;
                }

                else
                {
                    return "LoginUsr.aspx/0";
                    //Response.Redirect("LoginUsr.aspx");
                }
            }
        }

        public bool CustomValidator1(String NombreMembresia)
        {
            String validacion;
            validacion = NombreMembresia;
            DDAOadministrador datos = new DDAOadministrador();
            DataTable resul = datos.verificarMembresia(validacion);
            if (resul.Rows.Count > 0)
                return false;
            else
                return true;
        }

        public void btn1(bool IsValid,String NombreMembresia,String TB_Tiempo,String TB_Valor,Object sesion)
        {
            if (IsValid)
            {
                 DDAOadministrador datos = new DDAOadministrador();
                String nombre = NombreMembresia.ToString();
                int tiempo = int.Parse(TB_Tiempo);
                double valor = double.Parse(TB_Valor);
                datos.registrarMembresia(nombre, tiempo, valor, ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public void btn2(bool IsValid,String NombreMembresia,String Label5,String TB_Tiempo,String TB_Valor,Object sesion)
        {
            if (IsValid)
            {
                String categoria;
                categoria = NombreMembresia.ToString();
                DDAOadministrador datos = new DDAOadministrador();
                datos.ModificarMembresia(categoria, Label5, int.Parse(TB_Tiempo.ToString()), Double.Parse(TB_Valor.ToString()), ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
                //Button1.Visible = true;
                //Button2.Visible = false;
                //NombreMembresia.Text = null;
                //TB_Tiempo.Text = null;
                //TB_Valor.Text = null;
                //GridView2.DataBind();
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public bool CustomValidator2(String NombreMembresia,String Label5)
        {
            String validacion;
            validacion = NombreMembresia.ToString();
            if (validacion.Equals(Label5.ToString()))
            {
                return true;
            }
            else
            {
                DDAOadministrador datos = new DDAOadministrador();
                DataTable resul = datos.verificarMembresia(validacion);
                if (resul.Rows.Count >= 1)
                    return false;
                else
                    return true;
            }
        }
    }
}
