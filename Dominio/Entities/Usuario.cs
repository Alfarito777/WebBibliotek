using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Usuario: EntidadBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public int TipoUsuario { get; set; }
        public string Descripcion { get; set; }
    }
}
