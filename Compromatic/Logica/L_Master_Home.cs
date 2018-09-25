using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;

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
                DDAOProducto DAO_Producto = new DDAOProducto();
                data.Productos = DAO_Producto.TodoProductos();
                //Session["Tienda"] = DAO_Producto.TodoProductos();
                data.Url= "Store.aspx";
                //Response.Redirect("Store.aspx");
                return data;
            }
            DDAOHome datos = new DDAOHome();
            String palabra = busqueda;
            palabra = palabra.Replace(' ', '|');
            if (datos.Buscador(palabra).Rows.Count > 0)
            {
                data.Productos= datos.Buscador(palabra);
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
                    DDAOUsuario DB = new DDAOUsuario();
                    UEUsuario data = new UEUsuario();
                    data.IdUsr = int.Parse(Sess.Rows[0]["idUsuario"].ToString());
                    data.Sessiones = DB.GET_NUM_SESSION(data);
                    data.Sessiones = data.Sessiones - 1;
                    DB.actualizar_session(data);
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
                    DDAOEmpresa db = new DDAOEmpresa();
                    UEUEmpresa data = new UEUEmpresa();
                    data.Id = int.Parse(Sess.Rows[0]["idEmpresa"].ToString());
                    data.Sessiones = db.GET_NUM_SESSION(data);
                    data.Sessiones = data.Sessiones - 1;
                    db.ActualizarSesion(data);
                }
                else
                {
                    //para el usuario
                    DDAOUsuario DB = new DDAOUsuario();
                    UEUsuario data = new UEUsuario();
                    data.IdUsr = int.Parse(Sess.Rows[0]["idUsuario"].ToString());
                    data.Sessiones = DB.GET_NUM_SESSION(data);
                    data.Sessiones = data.Sessiones - 1;
                    DB.actualizar_session(data);
                }
            }
        }
    }
}

