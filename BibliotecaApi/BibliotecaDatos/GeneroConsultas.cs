using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDatos
{
    public class GeneroConsultas
    {
        public IList<Genero> ObtenerGeneros() {
            using (var context = new BibliotecaEntitiesORM())
            {
                var res = (from g in context.Generos                           
                           select g).ToList();
                return res;
            }
        }

        public IList<Libro> ObtenerLibrosPorGenero(int idGenero)
        {
            using (var context = new BibliotecaEntitiesORM())
            {
                var res = (from l in context.Libros.Include("Genero").Include("Autore").Include("EstadosLectura")
                           where l.IdGenero == idGenero
                           select l).ToList();
                return res;
            }
        }        
    }
}


