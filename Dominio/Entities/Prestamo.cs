using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Prestamo: EntidadBase
    {
        public Libro Libro { get; set; }
        public int LibroId { get; set; }

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public DateOnly FechaPrestamo { get; set; }
        public DateOnly FechaMaxPrestamo { get; set; }
        public string Descripcion { get; set; }
    }
}
