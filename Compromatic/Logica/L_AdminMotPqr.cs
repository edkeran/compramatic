using System;
using System.Data;
using Utilitarios;
using DatosPersistencia;

namespace Logica
{
    public class L_AdminMotPqr
    {
        public String page_load(Object Session,Object sesion)
        {
            if (Session == null)
            {
                return "LoginUsr.aspx/0";
                //Response.Redirect("LoginUsr.aspx");
            }
            else
            {
                if (int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString()) == 1)
                {

                    int num = int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString());
                    return "0/"+num;
                }

                else
                {
                    return "LoginUsr.aspx/0";
                    //Response.Redirect("LoginUsr.aspx");
                }
            }
        }

        public void B_RegistrarMQueja_Click(bool IsValid,String nomQueja,Object sesion)
        {
            if (IsValid)
            {
                String nom = nomQueja;
                //DDAOadministrador datos = new DDAOadministrador();
                UEUQueja encQuej = new UEUQueja();
                encQuej.Nom_queja = nom;
                encQuej.Modifby = ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString();
                //TOCA REPROGRAMAR EL INSERT INTO
                DB_ReasosnsPQR daoPqr = new DB_ReasosnsPQR();
                daoPqr.insertar_queja(encQuej);
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public bool validarQueja(String NombreQueja)
        {
            String validacion;
            validacion = NombreQueja;
            DB_ReasosnsPQR daoPqr = new DB_ReasosnsPQR();
            DataTable resul=daoPqr.verficarQueja(validacion);
            //DDAOadministrador datos = new DDAOadministrador();
            //DataTable resul = datos.verificarQueja(validacion);

            if (resul.Rows.Count > 0)
                return false;
            else
               return true;
        }

        public void registrarMReport(String NombreReporte,Object sesion,bool IsValid)
        {
            if (IsValid)
            {
                String nom = NombreReporte;
                //DDAOadministrador datos = new DDAOadministrador();
                UEUMotiRepo dataInsert = new UEUMotiRepo();
                dataInsert.DesMotiv = nom;
                dataInsert.ModifBy = ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString();
                //datos.registrarReporte(nom, ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
                DB_ReasosnsPQR daoRpo = new DB_ReasosnsPQR();
                daoRpo.insertar_reporte(dataInsert);
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public bool serverValidate1(String NombreReporte)
        {
            String validacion;
            validacion = NombreReporte;
            DB_ReasosnsPQR datos = new DB_ReasosnsPQR();
            //DDAOadministrador datos = new DDAOadministrador();
            DataTable resul = datos.verficarReporte(validacion);
            if (resul.Rows.Count > 0)
               return false;
            else
                return true;
        }

        public void BTN_2(bool IsValid,String NombreQueja,String NomQueja,Object sesion)
        {
            if (IsValid)
            {
                //DDAOadministrador datos = new DDAOadministrador();
                DB_ReasosnsPQR daoQuej = new DB_ReasosnsPQR();
                UEUQueja encQuej = new UEUQueja();
                encQuej.Nom_queja = NombreQueja;
                encQuej.Modifby = ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString();
                encQuej.Id_queja = int.Parse(NomQueja);
                daoQuej.modif_queja(encQuej);
                //datos.ModificarMotivoQueja(NombreQueja, int.Parse(NomQueja), ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }

        public void BTN_1(bool IsValid,String NombreReporte,String nomReporte,Object sesion)
        {
            if (IsValid)
            {
                //DDAOadministrador datos = new DDAOadministrador();
                UEUMotiRepo report = new UEUMotiRepo();
                report.DesMotiv = NombreReporte;
                report.IdMoti = int.Parse(nomReporte);
                report.ModifBy = ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString();
                //datos.ModificarMotivoReporte(NombreReporte, int.Parse(nomReporte), ((DataTable)(sesion)).Rows[0]["nomUsuario"].ToString());
                DB_ReasosnsPQR daoRep = new DB_ReasosnsPQR();
                daoRep.actualizar_reporte(report);
                //YA CASI !!!!!! ILL DO IT 

            }
            else
            {
                throw new ArgumentException("Valido");
            }
        }
    }
}
