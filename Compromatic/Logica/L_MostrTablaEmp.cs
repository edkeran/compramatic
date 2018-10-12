using System;
using System.Data;
using Utilitarios;

namespace Logica
{
    public class L_MostrTablaEmp
    {
        public U_AuxQuejAdm pageLoad(Object Session,Object sesion,int GV_count)
        {
            U_AuxQuejAdm repo = new U_AuxQuejAdm();
            if (Session == null)
            {
                repo.Redir = "LoginUsr.aspx";
                repo.Num = 0;
                repo.AcceHeader = false;
                //Response.Redirect("LoginUsr.aspx");
            }
            else
            {
                if (int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString()) == 1)
                {
                    if (GV_count > 0)
                    {
                        repo.AcceHeader = true;
                        repo.Redir = "0";
                        repo.Num = 0;
                        //GridView1.UseAccessibleHeader = true;
                        //GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    int num = int.Parse(((DataTable)(sesion)).Rows[0]["idTipo"].ToString());
                }
                else
                {
                    repo.AcceHeader = false;
                    repo.Redir = "LoginUsr.aspx";
                    repo.Num = 0;
                    //Response.Redirect("LoginUsr.aspx");
                }
            }
            return repo;
        }
    }
}
