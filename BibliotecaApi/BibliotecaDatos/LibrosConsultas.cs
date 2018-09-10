using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BibliotecaDatos
{
    public class LibrosConsultas
    {
        public IList<Libro> ObtenerLibros()
        {
            using (var context = new BibliotecaEntitiesORM())
            {
                return (from l in context.Libros.Include("Genero").Include("Autore").Include("EstadosLectura")
                        select l).ToList();
            }
        }

        public IList<Libro> ObtenerLibrosPorFiltro(int? IdAutor, int? IdEstadoLectura, int? IdGenero)
        {
            using (var context = new BibliotecaEntitiesORM())
            {
                return (from l in context.Libros.Include("Genero").Include("Autore").Include("EstadosLectura")
                        where l.IdAutor == IdAutor
                        where l.IdEstadoLectura == IdEstadoLectura
                        where l.IdGenero == IdGenero
                        select l).ToList();
            }
        }

        public IList<Libro> ObtenerLibrosPorEstado(int idEstadoLectura)
        {
            using (var context = new BibliotecaEntitiesORM())
            {
                return (from l in context.Libros.Include("Genero").Include("Autore").Include("EstadosLectura")
                        where l.IdEstadoLectura == idEstadoLectura
                        select l).ToList();
            }
        }
        public IList<Libro> ObtenerLibrosLeidos()
        {
            return ObtenerLibrosPorEstado(4);
        }              
    }
}

