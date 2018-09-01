using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    //CLASE AUXILIAR PARA RETORNAR LA INFO A LA VISTA VALIDADA
    public class U_aux_loggin
    {
        private DataTable datos=null;

        public DataTable Datos { get => datos; set => datos = value; }

        private String new_page= "LoginUsr.aspx";

        public string New_page { get => new_page; set => new_page = value; }

        private String modal_message=null;

        public string Modal_message { get => modal_message; set => modal_message = value; }

        private String id_empresa = null;

        public string Id_empresa { get => id_empresa; set => id_empresa = value; }

    }
}
