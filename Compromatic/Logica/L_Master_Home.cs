using System;
using System.Data;
using Utilitarios;
using DatosPersistencia;

namespace Logica
{
   public class L_Master_Home
    {
        public bool validaciones(bool post,Object Session)
        {
            if (!post)
            {
                if (Session == null)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        public U_aux_master_home generar_datos_session(bool post,Object Session)
        {
            U_aux_master_home data = new U_aux_master_home();
            if (!post)
            {
                if (Session == null)
                {
                    return data;
                }
                else
                { 
                    DataTable datos = (DataTable)Session;
                    if (datos.Rows[0]["idTipo"].ToString() == "1" || datos.Rows[0]["idTipo"].ToString() == "3")
                    {
                        data.RutaFoto = datos.Rows[0]["rutaArchivo"].ToString() + datos.Rows[0]["nomArchivo"].ToString();
                        data.NomUsuario = datos.Rows[0]["nomUsuario"].ToString();
                        data.RegistroVisible = false;
                    }
                    if (datos.Rows[0]["idTipo"].ToString() == "2")
                    {
                        data.RutaFoto = datos.Rows[0]["rutaArchivo"].ToString() + datos.Rows[0]["nomArchivo"].ToString();
                        data.NomUsuario= datos.Rows[0]["nomEmpresa"].ToString();
                        data.RegistroVisible = false;
                    }
                    return data;
                }
            }
            return data;
        }

        //FUNCION BOTON
        public U_aux_master_home boton_buscar(String busqueda)
        {
            //FUNCION PARA REALIZAR LA BUSQUEDA DE LOS DATOS
            U_aux_master_home data = new U_aux_master_home();
            if (String.IsNullOrWhiteSpace(busqueda))
            {
                DB_Producto daoProducto = new DB_Producto();
                //DDAOProducto DAO_Producto = new DDAOProducto();
                data.Productos = daoProducto.get_all_products();
                //Session["Tienda"] = DAO_Producto.TodoProductos();
                data.Url= "Store.aspx";
                //Response.Redirect("Store.aspx");
                return data;
            }
            //DDAOHome datos = new DDAOHome();
            DB_Producto daoProd = new DB_Producto();
            String palabra = busqueda;
            palabra = palabra.Replace(' ', '|');
            //datos.Buscador(palabra).Rows.Count > 0
            if (daoProd.find_products(palabra).Rows.Count>0)
            {
                data.Productos = daoProd.find_products(palabra);
                //datos.Buscador(palabra);
                //Session["Tienda"] = datos.Buscador(palabra);
                data.Url="Store.aspx";
                //Response.Redirect("Store.aspx");
                return data;
            }
            else
            {
                data.Productos = null;
                data.Url = "";
                data.Modal_Info1 = "No se encontraron resultados";
                return data;
                //Modal("No se encontraron resultados");
            }
        }

        //FUNCION DEL LOGOUT GENERAL
        public void log_out(Object Session,Object sesion)
        {
            if (Session == null)
            {
                if (sesion != null)
                {
                    DataTable Sess = (DataTable)sesion;
                    DBUsr daoUsuario = new DBUsr();
                    //DDAOUsuario DB = new DDAOUsuario();
                    UEUsuario data = new UEUsuario();
                    data.IdUsr = int.Parse(Sess.Rows[0]["idUsuario"].ToString());
                    data.Sessiones = daoUsuario.obtener_sessiones_abiertas(data.IdUsr);
                    data.Sessiones = data.Sessiones - 1;
                    // DB.actualizar_session(data);
                    daoUsuario.update_session(data);
                }
                else
                {

                }
            }
            else
            {
                DataTable Sess = (DataTable)Session;
                if (Sess.Rows[0]["idTipo"].ToString() == "2")
                {
                    //para la empresa
                    DBEmpresa daoEmpresa= new DBEmpresa();
                    //DDAOEmpresa db = new DDAOEmpresa();
                    UEUEmpresa data = new UEUEmpresa();
                    data.Id = int.Parse(Sess.Rows[0]["idEmpresa"].ToString());
                    data.Sessiones = daoEmpresa.get_sessions(data.Id);
                    data.Sessiones = data.Sessiones - 1;
                    daoEmpresa.update_session(data);
                }
                else
                {
                    //para el usuario
                    //DDAOUsuario DB = new DDAOUsuario();
                    DBUsr daoUsuario = new DBUsr();
                    UEUsuario data = new UEUsuario();
                    data.IdUsr = int.Parse(Sess.Rows[0]["idUsuario"].ToString());
                    data.Sessiones = daoUsuario.obtener_sessiones_abiertas(data.IdUsr);
                    data.Sessiones = data.Sessiones - 1;
                    daoUsuario.update_session(data);
                }
            }
        }
    }
}

