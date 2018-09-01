using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EUEmpresa
/// </summary>
public class EUEmpresa
{

	public EUEmpresa()
	{
	}

    private String nit;

    public String Nit
    {
        get { return nit; }
        set { nit = value; }
    }
    private String nombre;

    public String Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }
    private String nomArchivo;

    public String NomArchivo
    {
        get { return nomArchivo; }
        set { nomArchivo = value; }
    }
    private String rutaArchivo;

    public String RutaArchivo
    {
        get { return rutaArchivo; }
        set { rutaArchivo = value; }
    }
    private String numero;

    public String Numero
    {
        get { return numero; }
        set { numero = value; }
    }
    private String correo;

    public String Correo
    {
        get { return correo; }
        set { correo = value; }
    }
    private String direccion;

    public String Direccion
    {
        get { return direccion; }
        set { direccion = value; }
    }
    private String contraseña;

    public String Contraseña
    {
        get { return contraseña; }
        set { contraseña = value; }
    }
    private int idTipo;

    public int IdTipo
    {
        get { return idTipo; }
        set { idTipo = value; }
    }

    private String fechaInicio;

    public String FechaInicio
    {
        get { return fechaInicio; }
        set { fechaInicio = value; }
    }
    private String fechaFin;

    public String FechaFin
    {
        get { return fechaFin; }
        set { fechaFin = value; }
    }

    private int idTipoMembresia;

    public int IdTipoMembresia
    {
        get { return idTipoMembresia; }
        set { idTipoMembresia = value; }
    }
    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private double calificacion;

    public double Calificacion
    {
        get { return calificacion; }
        set { calificacion = value; }
    }

   
}