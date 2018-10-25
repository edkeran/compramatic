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
            DB_ReasosnsPQR daoReport = new DB_ReasosnsPQR();
            return daoReport.traer_reportes();
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
            DB_Admin daoAdmin = new DB_Admin();
            return daoAdmin.MostrarVentasPorCategoria();
        }

        public List<UEUQueja> MostrarMotivos()
        {
            //DATATABLE PARA LOS MOTIVOS
            DB_ReasosnsPQR daoReason = new DB_ReasosnsPQR();
            return daoReason.traer_quejas();
        }

        public DataTable MostrarCategoria()
        {
            DB_Producto db = new DB_Producto();
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
            DB_Tag daoTag = new DB_Tag();
            DataTable Tags = new DataTable();
            UEUTag EU_Tag = new UEUTag();
            //DDAOTag DAO_Tag = new DDAOTag();
            //daoTag.MostrarTags(EU_Tag);
            EU_Tag.IdProducto = idProducto;
            Tags = daoTag.MostrarTags(EU_Tag);
            return Tags;
        }

        public DataTable ProductosBajoI(int idEmpresa)
        {
            DB_Admin daoAdmin = new DB_Admin();
            //DDAOProducto db = new DDAOProducto();
            return daoAdmin.ProductosBajoI(idEmpresa);
        }

        public DataTable MostrarTipos()
        {
            DBTipoMembresia daoTipoMem = new DBTipoMembresia();
            return daoTipoMem.MostrarTipos();
        }

        public DataTable Reportes()
        {
            DB_Admin adm = new DB_Admin();
            return adm.Reportes();
        }

        public DataTable SolicitudesAceptadas()
        {
            DB_Solicit daoSolicit = new DB_Solicit();
            return daoSolicit.traer_accept();
        }

        public DataTable SolicitudesPendientes()
        {
            DB_Solicit daoSolicit = new DB_Solicit();
            return daoSolicit.traer_pendiente();
        }

        public DataTable SolicitudesRechazadas()
        {
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
            return db.obtenerUsuario();
        }

        public DataTable MostrarEmpresas(int idBusqueda)
        {
            DB_Admin daoAdmin = new DB_Admin();
            //DDAOadministrador db = new DDAOadministrador();
            return daoAdmin.MostrarEmpresas(idBusqueda);
        }

        public DataTable MostrarVentasPorEmpresa()
        {
            DB_Admin daoAdministrador = new DB_Admin();
            //DDAOadministrador db = new DDAOadministrador();
            return daoAdministrador.MostrarVentasPorEmpresa();
        }

        public DataTable MostrarPQRAdministrador()
        {
            DB_ReasosnsPQR daoPQR = new DB_ReasosnsPQR();
            DDAOPqr db = new DDAOPqr();
            return db.MostrarPQRAdministrador();
        }

        public DataTable MostrarPQRAempresa()
        {
            DB_Admin daoAdm = new DB_Admin();
            return daoAdm.pqr_empresa();
        }

        public DataTable MostrarPQRCliente()
        {
            DB_ReasosnsPQR daoPQR = new DB_ReasosnsPQR();
            return daoPQR.MostrarPQRcliente();
        }
    }
}
