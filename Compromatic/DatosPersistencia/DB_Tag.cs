using System.Data;
using System.Linq;
using Utilitarios;

namespace DatosPersistencia
{
    public class DB_Tag
    {
        public DataTable MostrarTags(UEUTag tag)
        {
            using (var db= new Mapeo("public"))
            {
                var data = (from palabraClave in db.tag
                            where palabraClave.IdProducto==tag.IdProducto
                            select palabraClave);
                ListToDataTable conv = new ListToDataTable();
                DataTable res = conv.ToDataTable<UEUTag>(data.ToList<UEUTag>());
                return res;
            }
        }
    }
}
