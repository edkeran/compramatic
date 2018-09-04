using System;
using System.Collections.Generic;
using System.Data;
using Datos;
using Utilitarios;

namespace Logica
{
    public class L_QuejasAdmin
    {
        public U_AuxQuejAdm page_load(Object Session,int GV_Rows,Object TableSecHead,Object Session2)
        {
            U_AuxQuejAdm respo = new U_AuxQuejAdm();
            if (Session == null)
            {
                respo.AcceHeader = false;
                respo.Redir= "LoginUsr.aspx";
                respo.Header1 = null;
                //Response.Redirect("LoginUsr.aspx");
            }
            else
            {
                if (int.Parse(((DataTable)(Session2)).Rows[0]["idTipo"].ToString()) == 1)
                {
                    if (GV_Rows > 0)
                    {
                        respo.AcceHeader = true;
                        respo.Header1 = TableSecHead;
                        //GridView1.UseAccessibleHeader = true;
                        //GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    int num = int.Parse(((DataTable)(Session2)).Rows[0]["idTipo"].ToString());
                    respo.Num = num;
                }

                else
                {
                    respo.AcceHeader = false;
                    respo.Redir = "LoginUsr.aspx";
                    respo.Header1 = null;
                    //Response.Redirect("LoginUsr.aspx");
                }
            }
            return respo;
        }
    }
}
