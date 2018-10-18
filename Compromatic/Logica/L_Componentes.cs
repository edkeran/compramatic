using System;
using System.Collections.Generic;
using System.Data;
using Datos;
using DatosPersistencia;
using Utilitarios;

namespace Logica
{
    public class L_Componentes
    {
        public List<UEUMotiRepo> MostrarMotivosReporte()
        {
            //DDAOPqr db = new DDAOPqr();
            DB_ReasosnsPQR daoReport = new DB_ReasosnsPQR();
            return daoReport.traer_reportes();
            //return db.MostrarMotivosReporte();
        }

        public DataTable MostrarArchivos(String nit)
        {
            DBEmpresa daoEmpresa = new DBEmpresa();
            UEUEmpresa EU_Empresa = new UEUEmpresa();
            EU_Empresa.Nit = nit;
            DataTable Archivos = daoEmpresa.MostrarArchivos(EU_Empresa);
            return Archivos;
        }

        public DataTable MostrarVentasPorCategoria()
        {
            DDAOadministrador db = new DDAOadministrador();
            return db.MostrarVentasPorCategoria();
        }

        public List<UEUQueja> MostrarMotivos()
        {
            //DATATABLE PARA LOS MOTIVOS
            DB_ReasosnsPQR daoReason = new DB_ReasosnsPQR();
            return daoReason.traer_quejas();
           // DDAOPqr db = new DDAOPqr();
            //return db.MostrarMotivos();
        }

        public DataTable MostrarCategoria()
        {
            DB_Producto db = new DB_Producto();
            //DDAOProducto db = new DDAOProducto();
            return db.MostrarCategoria();
        }

        public DataTable MostrarFoto(int idProducto)
        {
            DB_Producto DAO_Producto = new DB_Producto();
            //DDAOProducto DAO_Producto = new DDAOProducto();
            DataTable Fotos = DAO_Producto.get_picture_product(idProducto);
            return Fotos;
        }

        public DataTable MostrarTags(int idProducto)
        {
            DataTable Tags = new DataTable();
            UEUTag EU_Tag = new UEUTag();
            DDAOTag DAO_Tag = new DDAOTag();
            EU_Tag.IdProducto = idProducto;
            Tags = DAO_Tag.MostrarTags(EU_Tag);
            return Tags;
        }

        public DataTable ProductosBajoI(int idEmpresa)
        {
            DDAOProducto db = new DDAOProducto();
            return db.ProductosBajoI(idEmpresa);
        }

        public DataTable MostrarTipos()
        {
            DDAOMembresia db = new DDAOMembresia();
            return db.MostrarTipos();
        }

        public DataTable Reportes()
        {
            DDAOadministrador db = new DDAOadministrador();
            return db.Reportes();
        }

        public DataTable SolicitudesAceptadas()
        {
            //DDAOadministrador db = new DDAOadministrador();
            DB_Solicit daoSolicit = new DB_Solicit();
            return daoSolicit.traer_accept();
            //return db.SolicitudesAceptadas();
        }

        public DataTable SolicitudesPendientes()
        {
            DB_Solicit daoSolicit = new DB_Solicit();
            return daoSolicit.traer_pendiente();
            //DDAOadministrador db = new DDAOadministrador();
            //return db.SolicitudesPendientes();
        }

        public DataTable SolicitudesRechazadas()
        {
            //DDAOadministrador db = new DDAOadministrador();
            //return db.SolicitudesRechazadas();
            DB_Solicit daoSolicit = new DB_Solicit();
            return daoSolicit.traer_rechaza();
        }

        public DataTable Membresia()
        {
            DB_Membresia daoMembresia = new DB_Membresia();
            return daoMembresia.mostrarMembresia();
        }

        public List<UEUCategoria> MostrarCategorias()
        {
            //metodo que me trae las categorias a modificar
            DBCategoria dao = new DBCategoria();
            List<UEUCategoria> data = dao.leer_categorias();
            return data;
        }

        public List<UEUsuario> MostrarClientes()
        {
            DBUsr db = new DBUsr();

            //DDAOadministrador db = new DDAOadministrador();
            return db.obtenerUsuario();
        }

        public DataTable MostrarEmpresas(int idBusqueda)
        {
            //CAMBIAR POR METODO GENERICO DE PERSISTENCIA

            DDAOadministrador db = new DDAOadministrador();
            return db.MostrarEmpresas(idBusqueda);
        }

        public DataTable MostrarVentasPorEmpresa()
        {
            DDAOadministrador db = new DDAOadministrador();
            return db.MostrarVentasPorEmpresa();
        }

        public DataTable MostrarPQRAdministrador()
        {
            DDAOPqr db = new DDAOPqr();
            return db.MostrarPQRAdministrador();
        }

        public DataTable MostrarPQRAempresa()
        {
            DB_Admin daoAdm = new DB_Admin();
            return daoAdm.pqr_empresa();
            //DDAOPqr db = new DDAOPqr();
           //return db.MostrarPQRAempresa();
        }

        public DataTable MostrarPQRCliente()
        {
            DB_ReasosnsPQR daoPQR = new DB_ReasosnsPQR();
            return daoPQR.MostrarPQRcliente();
        }
    }
}
