using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IPrestamoRepository
    {
        bool Registrar(Prestamo prestamo);
        Task<List<Prestamo>> ConsultarPrestamos();
        Prestamo Consultar(int id);
        Prestamo Consultar(string descripcion);
        Task<bool> EditarPrestamo(Prestamo prestamo);
        Task<bool> EliminarPrestamo(int id);
    }
}
