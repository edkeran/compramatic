﻿using System;
using System.Data;
using DatosPersistencia;

namespace Logica
{
    public class L_TopDiezUsr
    {
        public DataTable page_load(bool post,Object Session,DataTable old,String btn_text)
        {
            if (!post)
            {
                if (Session == null)
                {
                    return null;
                    //Response.Redirect("LoginUSr.aspx");
                }
                DataTable datos = (DataTable)Session;
                if (int.Parse(datos.Rows[0]["idTipo"].ToString()) != 3)
                {
                    return null;
                    //Response.Redirect("LoginUsr.aspx");
                }
                DataTable user = (DataTable)Session;
                //DDAOUsuario dao = new DDAOUsuario();
                //DataTable topten = dao.ObtenerTopTen(int.Parse(user.Rows[0]["idUsuario"].ToString()));
                DBUsr daoUser = new DBUsr();
                DataTable topten =daoUser.obtener_top_ten(int.Parse(user.Rows[0]["idUsuario"].ToString()));
                DataColumn column = new DataColumn();
                column.DefaultValue = btn_text;
                column.ColumnName="BTN_idioma";
                column.DataType = typeof(String);
                topten.Columns.Add(column);
                return topten;
            }
            else
            {
                throw new System.ArgumentException("No Refrescar Los Itemas", "no");
            }
        }

        public String redireccion(DataTable top)
        {
            if (top == null)
            {
                return "LoginUSr.aspx";
            }
            else
            {
                return "0";
            }
        }

        public DataTable RP_TopTen_ItemCommand(String comand,String comandArg)
        {
            if (comand.Equals("Ver"))
            {
                DB_Producto daoProducto = new DB_Producto();
                //DDAOProducto pdto = new DDAOProducto();
                DataTable product = new DataTable();
                product= daoProducto.obtener_producto(int.Parse(comandArg));
                return product;
            }
            else
            {
                return null;
            }
        }
    }
}
