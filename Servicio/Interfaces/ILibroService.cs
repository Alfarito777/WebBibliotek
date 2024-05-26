using Dominio.Dtos.LibroDto;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Interfaces
{
    public interface ILibroService
    {
        LibroCreadoDto Registrar(CrearLibroDto dto);
        Libro Consultar(int id);
        Task<List<Libro>> ConsultarLibros();
        Task<bool> EliminarLibro(int id);
        Task<bool> EditarLibro(Libro libro);
    }
}
