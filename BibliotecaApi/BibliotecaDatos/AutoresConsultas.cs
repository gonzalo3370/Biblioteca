using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos
{
    public class AutoresConsultas
    {
        public IList<Autore> ObtenerAutores()
        {
            using (var context = new BibliotecaEntitiesORM())
            {
                var res = (from a in context.Autores
                           select a).ToList();
                return res;
            }
        }
    }
}
