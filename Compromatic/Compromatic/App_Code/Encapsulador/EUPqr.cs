using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EUPqr
/// </summary>
public class EUPqr
{
    String descripcion;

    public String Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }
    int idEmpresa;

    public int IdEmpresa
    {
        get { return idEmpresa; }
        set { idEmpresa = value; }
    }
    int motivo;

    public int Motivo
    {
        get { return motivo; }
        set { motivo = value; }
    }

    private int idCliente;

    public int IdCliente
    {
        get { return idCliente; }
        set { idCliente = value; }
    }


}