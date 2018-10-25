using System;
using Utilitarios;
using DatosPersistencia;
using System.Data;

namespace Logica
{
    public class L_MasterIndex
    {
        public U_aux_MasterIndex page_load(Object Session)
        {
            U_aux_MasterIndex res = new U_aux_MasterIndex();
            if (Session == null)
            {
                res.DLL_perfilUsr1 = false;
                //DropDownPerfilUsr.Visible = false;
            }
            else
            {
                DataTable user = (DataTable)Session;
                String rutaFoto = user.Rows[0]["rutaArchivo"].ToString() + user.Rows[0]["nomArchivo"].ToString();
                res.RutaFoto = rutaFoto;
                res.NombreHeather= user.Rows[0]["nomUsuario"].ToString();
                res.DLL_perfilUsr1 = true;
                //IMG_PerfilHeatherNR.ImageUrl = rutaFoto;
                //LB_NombreHeatherNR.Text = user.Rows[0]["nomUsuario"].ToString();
            }
            return res;
        }

        public DataTable TB_Buscar(String palabra)
        {
            DB_Producto daoProd = new DB_Producto();
            //DDAOHome db = new DDAOHome();
            return daoProd.find_products(palabra);
        }
    }
}
