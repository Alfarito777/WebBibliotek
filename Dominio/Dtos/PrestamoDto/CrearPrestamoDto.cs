using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dtos.PrestamoDto
{
    public class CrearPrestamoDto
    {
        public int LibroId { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }

    }
}
