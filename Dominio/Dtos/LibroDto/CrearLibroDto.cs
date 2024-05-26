using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dtos.LibroDto
{
    public class CrearLibroDto
    {
        public string Titulo { get; set; }
        public string Autores { get; set; }
        public string Editorial { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Genero { get; set; }
        public string Descripcion { get; set; }
        public string Idioma { get; set; }

    }
}
