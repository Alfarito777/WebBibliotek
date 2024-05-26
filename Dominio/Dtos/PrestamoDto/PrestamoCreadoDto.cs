using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Dtos.PrestamoDto
{
    public class PrestamoCreadoDto
    {
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaMaxPrestamo { get; set; }
        public string Descripcion { get; set; }

    }
}
