using System;
using System.Data;
using Utilitarios;
using Datos;

namespace Logica
{
    public class L_AdminMotPqr
    {
        public String page_load(Object Session,Object sesion)
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
                    return "0/"+num;
                }

                else
                {
                    return "LoginUsr.aspx/0";
                    //Response.Redirect("LoginUsr.aspx");
                }
            }
        }

        public void B_RegistrarMQueja_Click(bool IsValid,String nomQueja,Object sesion)
        {
            if (IsValid)
            {
                String nom = nomQueja;
                DDAOadministrador datos = new DDAOadministrador();
                datos.registrarQueja(nom, ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
                //NombreQueja.Text = null;
                //GridView2.DataBind();
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public bool validarQueja(String NombreQueja)
        {
            String validacion;
            validacion = NombreQueja;
            DDAOadministrador datos = new DDAOadministrador();
            DataTable resul = datos.verificarQueja(validacion);
            if (resul.Rows.Count > 0)
                return false;
            else
               return true;
        }

        public void registrarMReport(String NombreReporte,Object sesion,bool IsValid)
        {
            if (IsValid)
            {
                String nom = NombreReporte;
                DDAOadministrador datos = new DDAOadministrador();
                datos.registrarReporte(nom, ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
                //NombreReporte.Text = null;
                //GridView1.DataBind();
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public bool serverValidate1(String NombreReporte)
        {
            String validacion;
            validacion = NombreReporte;
            DDAOadministrador datos = new DDAOadministrador();
            DataTable resul = datos.verificarReporte(validacion);
            if (resul.Rows.Count > 0)
               return false;
            else
                return true;
        }

        public void BTN_2(bool IsValid,String NombreQueja,String NomQueja,Object sesion)
        {
            if (IsValid)
            {
                DDAOadministrador datos = new DDAOadministrador();
                datos.ModificarMotivoQueja(NombreQueja, int.Parse(NomQueja), ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
                //B_RegistrarMQueja.Visible = true;
                //Button2.Visible = false;
                //NombreQueja.Text = null;
                //GridView2.DataBind();
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public void BTN_1(bool IsValid,String NombreReporte,String nomReporte,Object sesion)
        {
            if (IsValid)
            {
                DDAOadministrador datos = new DDAOadministrador();
                datos.ModificarMotivoReporte(NombreReporte, int.Parse(nomReporte), ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
                //B_RegistrarMReporte.Visible = true;
                // Button1.Visible = false;
                //NombreReporte.Text = null;
                //GridView1.DataBind();
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }
    }
}
