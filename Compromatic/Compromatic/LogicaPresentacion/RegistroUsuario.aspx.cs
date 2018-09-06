using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class Presentacion_RegistroEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }


    protected void BtnRegistrar_Click(object sender, EventArgs e)
    {
       try{
                L_Registro_Usr regi = new L_Registro_Usr();
                //DAOUsuario envio = new DAOUsuario();
                UEUsuario user = new UEUsuario();
                user.NomUsr = TB_FirstName.Text.ToString();
                user.ApelUsr = TB_LastName.Text.ToString();
                user.TelUsr = TB_Telefono.Text.ToString();
                user.CorreoUsr = TB_Email.Text.ToString();
                user.PassUsr = TB_Pass1.Text.ToString();
                user.CcUsr = TB_cc.Text.ToString();
                user.DirUsr = TB_Direccion.Text.ToString();
                String Mensaje_Validacion=regi.validaciones_Register(TB_Email.Text, TB_Pass1.Text, TB_Pass2.Text, CB_Terminos.Checked,user);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", "<script>Redir_Reg_Usr('" + Mensaje_Validacion + "')</script>");
        }
            finally
            {
                //Response.Redirect("RegistroUsuario.aspx",false);
            }
       
    }
    //CODIGO ORIGINAL
    /**
                if ((envio.ComprobarCorreo(TB_Email.Text))==1)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", "<script>alert('El correo ya existe.')</script>");
                }
                else if (!(TB_Pass1.Text == TB_Pass2.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", "<script>alert('Las contraseñas no coinciden.')</script>");
                }
                else if (CB_Terminos.Checked == false)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", "<script>alert('No has confirmado tu registro.')</script>");
                }
                //Seguridad Pass
                else if (TB_Pass1.Text.ToString().Length < 8)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", "<script>alert('Contraseña muy corta.')</script>");
                }

                else
                {
                    //Encapsulaciones de los datos:
                    //EUsuario user = new EUsuario();
                    user.NomUsr = TB_FirstName.Text.ToString();
                    user.ApelUsr = TB_LastName.Text.ToString();
                    user.TelUsr = TB_Telefono.Text.ToString();
                    user.CorreoUsr = TB_Email.Text.ToString();
                    user.PassUsr = TB_Pass1.Text.ToString();
                    user.CcUsr = TB_cc.Text.ToString();
                    user.DirUsr = TB_Direccion.Text.ToString();

                    DAOUsuario accion = new DAOUsuario();
                    accion.RegistrarUsuario(user,"");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Sripts", "<script>alert('Tu registro se ha sido realizado satisfactoriamente.')</script>");

                    TB_FirstName.Text = "";
                    TB_LastName.Text = "";
                    TB_Telefono.Text = "";
                    TB_Email.Text = "";
                    TB_Pass1.Text = "";
                    TB_Pass2.Text = "";
                    TB_cc.Text = "";
                    TB_Direccion.Text = "";
                    CB_Terminos.Checked = false;

                    Response.Redirect("LoginUsr.aspx");

                    //Fin encapsulacion
                }**/

}