using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dtos.UsuarioDto
{
    public class CrearUsuarioDto
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
