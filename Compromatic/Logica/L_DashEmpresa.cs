﻿using System;
using System.Data;
using Utilitarios;
using DatosPersistencia;

namespace Logica
{
    public class L_DashEmpresa
    {
        public String page_load(Object Session)
        {
            if (Session == null)
            {
                throw new System.ArgumentException("No Hay Session", "Paila");
                //Response.Redirect("LoginUsr.aspx");
            }
            else
            {
                return "0";
            }
        }

        public void RegistrarPqr(String descripcion, int idEmpresa, int idMotivo, String modif)
        {
            UEUPqr EU_Pqr = new UEUPqr();
            //DDAOPqr DAO_Pqr = new DDAOPqr();
            DB_ReasosnsPQR daoPqr = new DB_ReasosnsPQR();
            EU_Pqr.Descripcion = descripcion;
            EU_Pqr.IdEmpresa = idEmpresa;
            EU_Pqr.Motivo = idMotivo;
            daoPqr.RegistrarPqr(EU_Pqr, modif);
            //DAO_Pqr.RegistrarPqr(EU_Pqr, modif);
        }

        public void cerrar_session_empresa(DataTable sesion)
        {
            //DDAOEmpresa DB = new DDAOEmpresa();
            DBEmpresa daoEmp = new DBEmpresa();
            UEUEmpresa data = new UEUEmpresa();
            int ID = int.Parse(sesion.Rows[0]["idEmpresa"].ToString());
            data.Id = ID;
            //int Session = DB.GET_NUM_SESSION(data);
            int Session = daoEmp.get_sessions(data.Id);
            Session=Session-1;
            data.Sessiones = Session;
            //DB.ActualizarSesion(data);
            daoEmp.update_session(data);
        }
    }
}
