using System;
using System.Collections.Generic;
using System.Data;
using Utilitarios;

namespace Logica
{
    public class L_MostrarTablaCliente
    {
        public U_AuxQuejAdm pageLoad(Object Session,int GV1_Count,Object sesion,Object Header)
        {
            U_AuxQuejAdm rep = new U_AuxQuejAdm();
            if (Session== null)
            {
                rep.AcceHeader = false;
                rep.Redir = "LoginUsr.aspx";
                rep.Num = 0;
                //Response.Redirect("LoginUsr.aspx");
            }
            else
            {
                if (GV1_Count > 0)
                {
                    rep.AcceHeader = true;
                    rep.Header1 = Header;
                    rep.Redir = "0";
                }
                int num = int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString());
                rep.Num = num;
                rep.Redir = "0";
                if (int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString()) == 1)
                { }
                else
                {
                    rep.Num = 0;
                    rep.AcceHeader = false;
                    rep.Redir = "LoginUsr.aspx";
                    //Response.Redirect("LoginUsr.aspx");
                }
            }
            return rep;
        }
    }
}
