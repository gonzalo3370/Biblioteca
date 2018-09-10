using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos
{
    public class EstadosConsultas
    {
        public IList<EstadosLectura> ObtenerEstados()
        {
            using (var context = new BibliotecaEntitiesORM())
            {
                var res = (from e in context.EstadosLecturas
                           select e).ToList();
                return res;
            }
        }
    }
}
