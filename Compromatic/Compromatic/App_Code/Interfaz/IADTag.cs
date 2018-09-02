using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IADTag
/// </summary>
public class IADTag
{
    public DataTable MostrarTags(int idProducto)
    {
        DataTable Tags = new DataTable();
        EUTag EU_Tag = new EUTag();
        DAOTag DAO_Tag = new DAOTag();
        EU_Tag.IdProducto = idProducto;
        Tags = DAO_Tag.MostrarTags(EU_Tag);
        return Tags;
    }
    //METODO MIGRADO A l_administrar producto
	public void RegistrarPalabra(String palabra, int idProducto, String modif)
    {
        DAOTag DAO_Tag = new DAOTag();
        EUTag EU_Tag = new EUTag();
        EU_Tag.Palabra = palabra;
        EU_Tag.IdProducto = idProducto;

        DAO_Tag.AgregarTag(EU_Tag, modif);
    }
    //METODO MIGRADO
    public void BorrarPalabra(int idPalabra,String modif)
    {
        DAOTag DAO_Tag = new DAOTag();
        EUTag EU_Tag = new EUTag();
        EU_Tag.IdTag = idPalabra;
        DAO_Tag.EliminarTag(EU_Tag,modif);
    }
}