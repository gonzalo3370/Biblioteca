using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaApi.Models
{
    public class LibroDTO
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string EstadoLectura { get; set; }
        public int? Publicacion { get; set; }
    }
}