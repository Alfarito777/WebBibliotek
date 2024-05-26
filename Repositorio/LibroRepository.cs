using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Repositorio.Data;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class LibroRepository: ILibroRepository
    {
        private readonly AppDbContext _context;

        public LibroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Libro>> ConsultarLibros()
        {
            return  _context.Libros.ToList();
            
        }
        public Libro Consultar(int id)
        {
            return _context.Libros.Find(id);
        }

        public Libro Consultar(string descripcion)
        {
            return _context.Libros.FirstOrDefault(x => x.Descripcion.Equals(descripcion));
        }

        public bool Registrar(Libro libro)
        {
            _context.Add(libro);
            return _context.SaveChanges() > 0;
        }

        

        public async Task<bool> EditarLibro(Libro libro)
        {
            try
            {
                var libroe = await (from l in _context.Libros
                                    where l.Id == libro.Id
                                    select l).FirstOrDefaultAsync();

                if (libroe == null) return false;

                libroe.Titulo = libro.Titulo;
                libroe.Autores = libro.Autores;
                libroe.Editorial = libro.Editorial;
                libroe.FechaPublicacion = libro.FechaPublicacion;
                libroe.ISBN = libro.ISBN;
                libroe.Descripcion = libro.Descripcion;
                libroe.Idioma = libro.Idioma;
                libroe.Id = libro.Id;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> EliminarLibro(int id)
        {
            try
            {
                var libro = _context.Libros.Find(id);

                _context.Libros.Remove(libro);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        
    }
}
