using System;
using System.Collections.Generic;
using System.Data;
using Datos;
using Utilitarios;

namespace Logica
{
    public class L_Componentes
    {
        public DataTable MostrarMotivosReporte()
        {
            DDAOPqr db = new DDAOPqr();
            return db.MostrarMotivosReporte();
        }

        public DataTable MostrarArchivos(String nit)
        {
            DDAOEmpresa DAO_Empresa = new DDAOEmpresa();
            UEUEmpresa EU_Empresa = new UEUEmpresa();
            EU_Empresa.Nit = nit;
            DataTable Archivos = DAO_Empresa.MostrarArchivos(EU_Empresa);
            return Archivos;
        }

        public DataTable MostrarVentasPorCategoria()
        {
            DDAOadministrador db = new DDAOadministrador();
            return db.MostrarVentasPorCategoria();
        }

        public DataTable MostrarMotivos()
        {
            DDAOPqr db = new DDAOPqr();
            return db.MostrarMotivos();
        }

        public DataTable MostrarCategoria()
        {
            DDAOProducto db = new DDAOProducto();
            return db.MostrarCategoria();
        }

        public DataTable MostrarFoto(int idProducto)
        {
            DDAOProducto DAO_Producto = new DDAOProducto();
            DataTable Fotos = DAO_Producto.MostrarFotoProducto(idProducto);
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
            DDAOadministrador db = new DDAOadministrador();
            return db.SolicitudesAceptadas();
        }

        public DataTable SolicitudesPendientes()
        {
            DDAOadministrador db = new DDAOadministrador();
            return db.SolicitudesPendientes();
        }

        public DataTable SolicitudesRechazadas()
        {
            DDAOadministrador db = new DDAOadministrador();
            return db.SolicitudesRechazadas();
        }

        public DataTable Membresia()
        {
            DDAOadministrador db = new DDAOadministrador();
            return db.Membresia();
        }

        public DataTable MostrarCategorias()
        {
            DDAOadministrador db = new DDAOadministrador();
            return db.MostrarCategorias();
        }

        public DataTable MostrarClientes(int idBusqueda)
        {
            DDAOadministrador db = new DDAOadministrador();
            return db.MostrarClientes(idBusqueda);
        }

        public DataTable MostrarEmpresas(int idBusqueda)
        {
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
            DDAOPqr db = new DDAOPqr();
            return db.MostrarPQRAempresa();
        }

        public DataTable MostrarPQRCliente()
        {
            DDAOPqr db = new DDAOPqr();
            return db.MostrarPQRCliente();
        }
    }
}
