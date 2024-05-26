using Dominio.Dtos.LibroDto;
using Dominio.Dtos.PrestamoDto;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Interfaces
{
    public interface IPrestamoService
    {
        PrestamoCreadoDto Registrar(CrearPrestamoDto dto);
        Prestamo Consultar(int id);
        Task<List<Prestamo>> ConsultarPrestamos();
        Task<bool> EliminarPrestamo(int id);
        Task<bool> EditarPrestamo(Prestamo prestamo);
    }
}
