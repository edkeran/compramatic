using System;
using System.Data;
using System.Web.UI;
using Utilitarios;
using Logica;

public partial class Presentacion_RegistroEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_RegistroEmpresa emp = new L_RegistroEmpresa();
        String inf = emp.validar_session(Session["Sesion"]);
        String texto = "<script>redireccionar('"+inf+"');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", texto);
        //FUNCIONES A MIGRAR
        DateTime Fecha = DateTime.Now.Date;
        TB_FechaInicio.Text = Fecha.ToShortDateString();
        Fecha=Fecha.AddMonths(1);
        TB_FechaFinal.Text = Fecha.ToShortDateString();
        //DAOMembresia DAO_Membresia = new DAOMembresia();
        DataTable Membresia = new DataTable();
        Membresia = emp.mostrar_Membresia(1);
        TB_Precio.Text = "$" + Membresia.Rows[0]["valorMembresia"].ToString() + " COP";
    }

    protected void BTN_Registro_Click(object sender, EventArgs e)
    {
        L_RegistroEmpresa emp = new L_RegistroEmpresa();
        DAOEmpresa envio = new DAOEmpresa();
        //CAMBIAR A JS LA VALIDACION
        Boolean val = emp.Validar_Existencia_Correo(TB_Email.Text);
        String extension = System.IO.Path.GetExtension(FU_Foto.PostedFile.FileName);
        String nombreArchivo = TB_Nit.Text;
        String saveLocation = (Server.MapPath("~\\Archivos\\FotosPerfil") + "\\" + nombreArchivo+extension);
        U_aux_reg_emp data = new U_aux_reg_emp();
        data = emp.validar_extenciones(extension, TB_Contraseña.Text, TB_Contraseña2.Text, val);
        emp.CrearEmpresa(TB_Nit.Text, TB_NombreCompañia.Text, nombreArchivo + extension, "../Archivos/FotosPerfil/", TB_Telefono.Text, TB_Direccion.Text, TB_Email.Text, TB_Contraseña.Text, 2, TB_FechaFinal.Text, TB_FechaInicio.Text, int.Parse(DDL_Memebresia.SelectedValue),"",data.Valido);
        emp.guardar_imagen(FU_Foto.PostedFile, data.Valido, saveLocation);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "sc", "Redir_Reg_Emp('" + data.Info + "','" + data.Valido + "');", true);
        Modal("Correo Existente", val);
    }

    protected void DDL_Memebresia_SelectedIndexChanged(object sender, EventArgs e)
    {
        L_RegistroEmpresa emp = new L_RegistroEmpresa();
        DataTable Membresia = new DataTable();
        DateTime Fecha = DateTime.Now.Date;
        Membresia = emp.mostrar_Membresia(int.Parse(DDL_Memebresia.SelectedValue));
        TB_Precio.Text = "$" + Membresia.Rows[0]["valorMembresia"].ToString() + " COP";   
        TB_FechaInicio.Text = Fecha.ToShortDateString();
        Fecha = Fecha.AddMonths(int.Parse(Membresia.Rows[0]["tiempoMembresia"].ToString()));
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