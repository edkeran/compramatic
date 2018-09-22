using System;
using System.Web.UI;
using Utilitarios;
using Logica;
using System.Collections;

public partial class Presentacion_RegistroEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 15;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.title.Text= compIdioma["title"].ToString();
            this.desc1.InnerText= compIdioma["desc1"].ToString();
            this.HL_Index.Text= compIdioma["HL_Index"].ToString();
            this.reg.InnerHtml= compIdioma["reg"].ToString()+ "<small id='desc_reg'>"+ compIdioma["desc_reg"].ToString() + "</small>";
            this.LB_Nmbr.Text= compIdioma["LB_Nmbr"].ToString();
            this.LB_ID.Text= compIdioma["LB_ID"].ToString();
            this.LB_Dir.Text= compIdioma["LB_Dir"].ToString();
            this.LB_Email.Text= compIdioma["LB_Email"].ToString();
            this.LB_Pass.Text= compIdioma["LB_Pass"].ToString();
            this.CB_Terminos.Text= compIdioma["CB_Terminos"].ToString();
            this.TB_FirstName.Attributes.Remove("placeholder");
            this.TB_FirstName.Attributes.Add("placeholder", compIdioma["TB_FirstName"].ToString());
            this.TB_LastName.Attributes.Remove("placeholder");
            this.TB_LastName.Attributes.Add("placeholder", compIdioma["TB_LastName"].ToString());
            this.TB_cc.Attributes.Remove("placeholder");
            this.TB_cc.Attributes.Add("placeholder", compIdioma["TB_cc"].ToString());
            this.TB_Telefono.Attributes.Remove("placeholder");
            this.TB_Telefono.Attributes.Add("placeholder", compIdioma["TB_Telefono"].ToString());
            this.TB_Direccion.Attributes.Remove("placeholder");
            this.TB_Direccion.Attributes.Add("placeholder", compIdioma["TB_Direccion"].ToString());
            this.TB_Email.Attributes.Remove("placeholder");
            this.TB_Email.Attributes.Add("placeholder", compIdioma["TB_Email"].ToString());
            this.TB_Pass1.Attributes.Remove("placeholder");
            this.TB_Pass1.Attributes.Add("placeholder", compIdioma["TB_Pass1"].ToString());
            this.TB_Pass2.Attributes.Remove("placeholder");
            this.TB_Pass2.Attributes.Add("placeholder", compIdioma["TB_Pass2"].ToString());
            this.BtnRegistrar.Text= compIdioma["BtnRegistrar"].ToString();
            this.div_alr.InnerHtml= compIdioma["div_alr"].ToString()+ "<a href='../Presentacion/LoginUsr.aspx' id='here'>"+ 
                compIdioma["here"].ToString() + "</a>"+" "+compIdioma["end_div"].ToString();
        }
        catch (Exception ex)
        { }
    }

    protected void BtnRegistrar_Click(object sender, EventArgs e)
    {
       try{
                L_Registro_Usr regi = new L_Registro_Usr();
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
}