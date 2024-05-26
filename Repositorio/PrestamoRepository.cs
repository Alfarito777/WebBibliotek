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
    public class PrestamoRepository: IPrestamoRepository
    {
        private readonly AppDbContext _context;

        public PrestamoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Prestamo>> ConsultarPrestamos()
        {
            return _context.Prestamos.ToList();

        }
        public Prestamo Consultar(int id)
        {
            return _context.Prestamos.Find(id);
        }

        public Prestamo Consultar(string descripcion)
        {
            return _context.Prestamos.FirstOrDefault(x => x.Descripcion.Equals(descripcion));
        }

        public bool Registrar(Prestamo prestamo)
        {
            _context.Add(prestamo);
            return _context.SaveChanges() > 0;
        }



        public async Task<bool> EditarPrestamo(Prestamo prestamo)
        {
            try
            {
                var prestamoe = await (from p in _context.Prestamos
                                    where p.Id == prestamo.Id
                                    select p).FirstOrDefaultAsync();

                if (prestamoe == null) return false;

                prestamoe.LibroId = prestamo.LibroId;
                prestamoe.UsuarioId = prestamo.UsuarioId;
                prestamoe.FechaPrestamo = prestamo.FechaPrestamo;
                prestamoe.FechaMaxPrestamo = prestamo.FechaMaxPrestamo;
               

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> EliminarPrestamo(int id)
        {
            try
            {
                var prestamo = _context.Prestamos.Find(id);

                _context.Prestamos.Remove(prestamo);
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
