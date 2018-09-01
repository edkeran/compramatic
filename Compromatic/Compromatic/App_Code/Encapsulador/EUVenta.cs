using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EUVenta
/// </summary>
public class EUVenta
{
	public EUVenta()
	{
	}
    private int valor;

    public int Valor
    {
        get { return valor; }
        set { valor = value; }
    }
    private int cantidad;

    public int Cantidad
    {
        get { return cantidad; }
        set { cantidad = value; }
    }
    private int idVenta;

    public int IdVenta
    {
        get { return idVenta; }
        set { idVenta = value; }
    }
    private int idUsr;

    public int IdUsr
    {
        get { return idUsr; }
        set { idUsr = value; }
    }

    private int idProducto;

    public int IdProducto
    {
        get { return idProducto; }
        set { idProducto = value; }
    }

    private int estadoVenta;

    public int EstadoVenta
    {
        get { return estadoVenta; }
        set { estadoVenta = value; }
    }
}