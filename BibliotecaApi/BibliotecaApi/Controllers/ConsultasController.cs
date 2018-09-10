using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BibliotecaApi.Models;
using BibliotecaDatos;


namespace BibliotecaApi.Controllers
{
    public class ConsultasController : ApiController
    {        
        public IEnumerable<GeneroDTO> GetGeneros()
        {
            var generoConsultas = new GeneroConsultas();
            var res = from g in generoConsultas.ObtenerGeneros()
                      select new GeneroDTO
                      {
                          IdGenero = g.IdGenero,
                          Genero = g.Nombre                   
                      };
            return res;
        }
        public IEnumerable<AutorDTO>  GetAutores()
        {
            var autoresConsultas = new AutoresConsultas();
            var res = from a in autoresConsultas.ObtenerAutores()
                      select new AutorDTO
                      {
                          IdAutor = a.IdAutor,
                          Nombre  = a.Nombre,
                          Apellido = a.Apellido
                      };
            return res;
        }
        public IEnumerable<EstadoDTO> GetEstados()
        {
            var estadosConsultas = new EstadosConsultas();
            var res = from e in estadosConsultas.ObtenerEstados()
                      select new EstadoDTO
                      {
                          IdEstadoLectura = e.IdEstadoLectura,
                          EstadoLectura = e.EstadoLectura
                      };
            return res;
        }

        [HttpPost]
        public IEnumerable<LibroDTO> GetLibrosFiltrados([FromBody]FiltroDTO filtrado)
        {
            var librosConsultas = new LibrosConsultas();
            var res = from l in librosConsultas.ObtenerLibrosPorFiltro(filtrado.IdAutor, filtrado.IdEstado, filtrado.IdGenero)
                      select new LibroDTO
                      {
                          Titulo = l.Titulo,
                          Autor = l.Autore.Nombre + " " + l.Autore.Apellido,
                          Genero = l.Genero.Nombre,
                          EstadoLectura = l.EstadosLectura.EstadoLectura
                      };
            return res;
        }

        public IEnumerable<LibroDTO> Genero(int id)
        {
            var generoConsultas = new GeneroConsultas();
            var res = from l in generoConsultas.ObtenerLibrosPorGenero(id)
                      select new LibroDTO
                      {
                          Titulo= l.Titulo,
                          Autor = l.Autore.Nombre + " " + l.Autore.Apellido,
                          EstadoLectura = l.EstadosLectura.EstadoLectura,
                          Genero = l.Genero.Nombre,
                          Publicacion = l.Publicacion
                      };
            return res;
        }     
        public IEnumerable<LibroDTO> Estado(int idEstado)
        {
            var librosConsultas = new LibrosConsultas();
            var res = from l in librosConsultas.ObtenerLibrosPorEstado(idEstado)
                      select new LibroDTO
                      {
                          Titulo = l.Titulo,
                          Autor = l.Autore.Nombre + " " + l.Autore.Nombre,
                          EstadoLectura = l.EstadosLectura.EstadoLectura,
                          Genero = l.Genero.Nombre,
                          Publicacion = l.Publicacion
                      };
            return res;
        }


        public IEnumerable<LibroDTO> GetLibros()
        {
            var librosConsultas = new LibrosConsultas();
            var res = from l in librosConsultas.ObtenerLibros()
                      select new LibroDTO
                      {
                          Titulo = l.Titulo,
                          Autor = l.Autore.Nombre + " " + l.Autore.Apellido,
                          Genero = l.Genero.Nombre,
                          EstadoLectura = l.EstadosLectura.EstadoLectura
                      };
            return res;
        }
    }
}
