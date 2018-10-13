using System;
using System.Data;
using System.Web.UI;
using Utilitarios;
using Logica;
using System.Collections;
using System.Globalization;
using System.Threading;

public partial class Presentacion_RegistroEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_RegistroEmpresa emp = new L_RegistroEmpresa();
        String inf = emp.validar_session(Session["Sesion"]);
        String texto = "<script>redireccionar('"+inf+"');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", texto);
        DateTime Fecha = DateTime.Now.Date;
        TB_FechaInicio.Text = Fecha.ToShortDateString();
        Fecha=Fecha.AddMonths(1);
        TB_FechaFinal.Text = Fecha.ToShortDateString();
        DataTable Membresia = new DataTable();
        Membresia = emp.mostrar_Membresia(1);
        TB_Precio.Text = "$" + Membresia.Rows[0]["Valor_mem"].ToString() + " COP";

        //Seteando Idiomas
        L_Idioma idiot = new L_Idioma();
        Object sesidioma = Session["idiomases"];
        Int32 formulario = 22;
        Int32 idiom = Convert.ToInt32(sesidioma);
        Hashtable compIdioma = new Hashtable();
        idiot.mostraridioma(formulario, idiom, compIdioma);
        try
        {
            this.title.Text= compIdioma["title"].ToString();
            this.asis_reg.InnerText= compIdioma["asis_reg"].ToString();
            this.HL_Index.Text= compIdioma["HL_Index"].ToString();
            this.id.InnerText= compIdioma["id"].ToString();
            this.cont.InnerText = compIdioma["cont"].ToString();
            this.ini_ses.InnerText= compIdioma["ini_ses"].ToString();
            this.info_pago.InnerText = compIdioma["info_pago"].ToString();
            this.end_reg.InnerText= compIdioma["End_reg"].ToString();
            this.id2.InnerText= compIdioma["id"].ToString();
            this.comp.InnerText= compIdioma["comp"].ToString();
            this.TB_Nit.Attributes.Remove("placeholder");
            this.TB_Nit.Attributes.Add("placeholder", compIdioma["comp"].ToString());
            this.nom_com.InnerText= compIdioma["nom_com"].ToString();
            this.TB_NombreCompañia.Attributes.Remove("placeholder");
            this.TB_NombreCompañia.Attributes.Add("placeholder", compIdioma["nom_com"].ToString());
            this.pic.InnerText= compIdioma["pic"].ToString();
            this.inf_cont.InnerText= compIdioma["inf_cont"].ToString();
            this.LB_Tel.InnerText= compIdioma["LB_Tel"].ToString();
            this.TB_Telefono.Attributes.Remove("placeholder");
            this.TB_Telefono.Attributes.Add("placeholder", compIdioma["LB_Tel"].ToString());
            this.dir.InnerText= compIdioma["dir"].ToString();
            this.TB_Direccion.Attributes.Remove("plceholder");
            this.TB_Direccion.Attributes.Add("placeholder", compIdioma["dir"].ToString());
            this.str_session.InnerText= compIdioma["str_session"].ToString();
            this.pass.InnerText = compIdioma["pass"].ToString();
            this.TB_Contraseña.Attributes.Remove("placeholder");
            this.TB_Contraseña.Attributes.Add("placeholder", compIdioma["pass"].ToString());
            this.conf_pass.InnerText= compIdioma["conf_pass"].ToString();
            this.TB_Contraseña2.Attributes.Remove("placeholder");
            this.TB_Contraseña2.Attributes.Add("placeholder", compIdioma["conf_pass"].ToString());
            this.pay.InnerText= compIdioma["pay"].ToString();
            this.member.InnerText= compIdioma["member"].ToString();
            this.LB_St_date.InnerText = compIdioma["LB_St_date"].ToString();
            this.LB_End_date.InnerText= compIdioma["LB_End_date"].ToString();
            this.price.InnerText= compIdioma["price"].ToString();
            this.End_reg1.InnerText= compIdioma["End_reg"].ToString();
            this.BTN_Registro.Text= compIdioma["BTN_Registro"].ToString();
            this.BTN_Cancelar.Text= compIdioma["BTN_Cancelar"].ToString();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Session["global"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["global"].ToString());
        }
        catch (Exception ex)
        { }

    }

    protected void BTN_Registro_Click(object sender, EventArgs e)
    {
        L_RegistroEmpresa emp = new L_RegistroEmpresa();
        Boolean val = emp.Validar_Existencia_Correo(TB_Email.Text);
        String extension = System.IO.Path.GetExtension(FU_Foto.PostedFile.FileName);
        String nombreArchivo = TB_Nit.Text;
        String saveLocation = (Server.MapPath("~\\Archivos\\FotosPerfil") + "\\" + nombreArchivo+extension);
        U_aux_reg_emp data = new U_aux_reg_emp();
        data = emp.validar_extenciones(extension, TB_Contraseña.Text, TB_Contraseña2.Text, val);
        //CAMBIAR PARAMETROS PARA CRUD EMPRESA
        emp.CrearEmpresa(TB_Nit.Text, TB_NombreCompañia.Text, nombreArchivo + extension, "../Archivos/FotosPerfil/", TB_Telefono.Text, TB_Direccion.Text, TB_Email.Text, TB_Contraseña.Text, 2, TB_FechaFinal.Text, TB_FechaInicio.Text, int.Parse(DDL_Memebresia.SelectedValue),"",data.Valido);
        emp.guardar_imagen(FU_Foto.PostedFile.InputStream, data.Valido, saveLocation);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "sc", "Redir_Reg_Emp('" + data.Info + "','" + data.Valido + "');", true);
        Modal("Correo Existente", val);
    }

    protected void DDL_Memebresia_SelectedIndexChanged(object sender, EventArgs e)
    {
        L_RegistroEmpresa emp = new L_RegistroEmpresa();
        DataTable Membresia = new DataTable();
        DateTime Fecha = DateTime.Now.Date;
        Membresia = emp.mostrar_Membresia(int.Parse(DDL_Memebresia.SelectedValue));
        TB_Precio.Text = "$" + Membresia.Rows[0]["Valor_mem"].ToString() + " COP";   
        TB_FechaInicio.Text = Fecha.ToShortDateString();
        Fecha = Fecha.AddMonths(int.Parse(Membresia.Rows[0]["Tmpo_mem"].ToString()));
        TB_FechaFinal.Text = Fecha.ToShortDateString();
    }

    protected void BTN_Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }

    public void Modal(String mensaje,Boolean crear)
    {
        String texto ="$('#modal-dialog').modal('show');Redir_Reg_Cor_Emp('"+crear+"');";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "ST", texto, crear);
        MensajeModal.Text = mensaje;
    }
}