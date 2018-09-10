using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibliotecaApi.Models
{
    public class FiltroDTO
    {
        public int? IdGenero { get; set; }
        public int? IdAutor { get; set; }
        public int? IdEstado { get; set; }
    }
}