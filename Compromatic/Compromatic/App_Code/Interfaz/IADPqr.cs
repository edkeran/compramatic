using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IADPqr
/// </summary>
public class IADPqr
{
    //Metodo Migrado
    public void RegistrarPqr(String descripcion, int idEmpresa, int idMotivo, String modif)
    {
        EUPqr EU_Pqr = new EUPqr();
        DAOPqr DAO_Pqr = new DAOPqr();
        EU_Pqr.Descripcion = descripcion;
        EU_Pqr.IdEmpresa = idEmpresa;
        EU_Pqr.Motivo = idMotivo;
        DAO_Pqr.RegistrarPqr(EU_Pqr, modif);
    }
}