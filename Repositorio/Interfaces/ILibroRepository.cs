using Dominio.Dtos.LibroDto;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface ILibroRepository
    {
        bool Registrar(Libro libro);
        Task<List<Libro>> ConsultarLibros();
        Libro Consultar(int id);
        Libro Consultar(string descripcion);
        Task<bool> EditarLibro(Libro libro);
        Task<bool> EliminarLibro(int id);

    }
}
