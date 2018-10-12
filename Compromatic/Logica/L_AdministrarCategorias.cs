using System;
using System.Data;
using Utilitarios;
using DatosPersistencia;

namespace Logica
{
    public class L_AdministrarCategorias
    {
        public void btn1(bool IsValid,String NombreCategoria,object sesion)
        {
            if (IsValid)
            {
                UEUCategoria catego= new UEUCategoria();
                String categoria;
                categoria = NombreCategoria;
                catego.nomCategoria=categoria;
                catego.ModifBy=((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString();
                DBCategoria daoCat = new DBCategoria();
                daoCat.insertar_categoria(catego);
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public bool ServerValidate(String NombreCategoria)
        {
            String validacion;
            validacion = NombreCategoria.ToString();
            if (validacion.Length <= 20)
               return true;
            else
               return false;
        }

        public bool ServerValidate2(String NombreCategoria)
        {
            String validacion;
            validacion = NombreCategoria;
            DBCategoria daoCat = new DBCategoria();
            //DDAOadministrador datos = new DDAOadministrador();
            //datos.verificarCategoria(validacion);
            DataTable resul = daoCat.verificar_categoria(validacion);
            if (resul.Rows.Count > 0)
                return false;
            else
                return true;
        }

        public void btn2(bool IsValid,String NombreCategoria,String Label5,Object sesion, String Id)
        {
            if (IsValid)
            {
                UEUCategoria categories = new UEUCategoria();
                String categoria;
                categoria = NombreCategoria;
                categories.nomCategoria = categoria;
                categories.Id_cate = int.Parse(Id);
                categories.ModifBy = ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString();
                DBCategoria daoCat = new DBCategoria();
                daoCat.editar_categoria(categories);
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }
    }
}
