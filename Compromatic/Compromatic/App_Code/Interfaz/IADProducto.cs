using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IADProducto
/// </summary>
public class IADProducto
{
    //METODO MIGRADO L_AgregarProducto
    public void ModificarInventario(int idProducto, int cantidad, int bajoInventario, String modif)
    {
        EUProducto EU_Producto = new EUProducto();
        DAOProducto DAO_Producto = new DAOProducto();

        EU_Producto.Id = idProducto;
        EU_Producto.Cantidad = cantidad;
        EU_Producto.BajoInventario = bajoInventario;
        DAO_Producto.ModificarInventario(EU_Producto, modif);
    }
    //Metodo migrado a L_AgregarProducto
    public void AgregarProducto(String nombre, int cantidad, double precio, String descripcion, int categoria, int idEmpresa, String modif)
    {
        DAOProducto DAO_Producto = new DAOProducto();
        EUProducto EU_Producto = new EUProducto();

        EU_Producto.Nombre = nombre;
        EU_Producto.Cantidad = cantidad;
        EU_Producto.Precio = precio;
        EU_Producto.Descripcion = descripcion;
        EU_Producto.Categoria = categoria;
        EU_Producto.IdEmpresa = idEmpresa;
        DAO_Producto.GuardarProducto(EU_Producto, modif);
    }

    public void BorrarProducto(int idProducto, String modif)
    {
        DAOProducto DAO_Producto = new DAOProducto();
        EUProducto EU_Producto = new EUProducto();

        EU_Producto.Id = idProducto;
        DAO_Producto.EliminarProducto(EU_Producto, modif);
    }

    public void ModificarProducto(String nombre, int cantidad, double precio, String descripcion, int categoria, int idProducto, String modif)
    {

        DAOProducto DAO_Producto = new DAOProducto();
        EUProducto EU_Producto = new EUProducto();

        EU_Producto.Nombre = nombre;
        EU_Producto.Cantidad = cantidad;
        EU_Producto.Precio = precio;
        EU_Producto.Descripcion = descripcion;
        EU_Producto.Categoria = categoria;
        EU_Producto.Id = idProducto;

        DAO_Producto.ModificarProducto(EU_Producto, modif);
    }

    public void RegistrarFoto(int idProducto, String nombreArchivo, String rutaArchivo, String modif)
    {
        DAOProducto DAO_Producto = new DAOProducto();
        EUProducto EU_Producto = new EUProducto();

        EU_Producto.Id = idProducto;
        EU_Producto.NomArchivo = nombreArchivo;
        EU_Producto.RutaArchivo = rutaArchivo;

        DAO_Producto.RegistrarFoto(EU_Producto, modif);
    }
    public void BorrarFoto(int idFoto)
    {
        DAOProducto DAO_Producto = new DAOProducto();
        EUProducto EU_Producto = new EUProducto();

        EU_Producto.IdFoto = idFoto;
        DAO_Producto.EliminarFoto(EU_Producto);
    }

    public DataTable MostrarFoto(int idProducto)
    {
        DAOProducto DAO_Producto = new DAOProducto();
        DataTable Fotos = DAO_Producto.MostrarFotoProducto(idProducto);
        return Fotos;
    }
}