﻿using Utilitarios;
using System.Data;
using System;
using DatosPersistencia;

namespace Logica
{
    public class L_AgregarProducto
    {
        public string page_load(bool postback,object Session)
        {
            if (!postback)
            {
                if (Session == null)
                {
                    return "LoginUsr.aspx";
                    //Response.Redirect("LoginUsr.aspx");
                }
                DataTable Empresa = (DataTable)Session;
                if (Empresa.Rows[0]["idTipo"].ToString() != "2")
                {
                    return "LoginUsr.aspx";
                    //Response.Redirect("LoginUsr.aspx");
                }
                if (int.Parse(Empresa.Rows[0]["estadoEmpresa"].ToString()) != 1)
                {
                    return "PerfilEmpresa.aspx";
                    //Response.Redirect("PerfilEmpresa.aspx");
                }
            }
            return "0";
        }
        //Metodo Para Agregar Un Producto
        public void AgregarProducto(String nombre, int cantidad, double precio, String descripcion, int categoria, int idEmpresa, String modif)
        {
            //DDAOProducto DAO_Producto = new DDAOProducto();
            DB_Producto daoProducto = new DB_Producto();
            UEUProducto EU_Producto = new UEUProducto();
            EU_Producto.Nombre = nombre;
            EU_Producto.Cantidad = cantidad;
            EU_Producto.Precio = precio;
            EU_Producto.Descripcion = descripcion;
            EU_Producto.Categoria = categoria;
            EU_Producto.IdEmpresa = idEmpresa;
            EU_Producto.ModifBy = modif;
            EU_Producto.BajoInventario = 1;
            EU_Producto.Estado_producto = 1;
            daoProducto.insertar_producto(EU_Producto);
            //DAO_Producto.GuardarProducto(EU_Producto, modif);
        }
    }
}
