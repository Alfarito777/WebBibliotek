using AutoMapper;
using Dominio.Dtos.LibroDto;
using Dominio.Dtos.PrestamoDto;
using Dominio.Entities;
using Repositorio.Interfaces;
using Servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class PrestamoService: IPrestamoService
    {
        private readonly IPrestamoRepository _repository;
        private readonly IMapper _mapper;

        public PrestamoService(IPrestamoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Prestamo>> ConsultarPrestamos()
        {
            return await _repository.ConsultarPrestamos();
        }

        public Prestamo Consultar(int id)
        {
            return _repository.Consultar(id);
        }

       
        

        public PrestamoCreadoDto Registrar(CrearPrestamoDto dto)
        {
            var existe = _repository.Consultar(dto.Descripcion);

            if (existe is null)
            {
                var prestamo = _mapper.Map<Prestamo>(dto);
                

                _repository.Registrar(prestamo);

                var prestamoCreado = _mapper.Map<PrestamoCreadoDto>(prestamo);

                return _mapper.Map<PrestamoCreadoDto>(prestamo);
                return prestamoCreado;

            }

            return null;
        }





        public async Task<bool> EditarPrestamo(Prestamo prestamo)
        {
            return await _repository.EditarPrestamo(prestamo);
        }

        public async Task<bool> EliminarPrestamo(int id)
        {
            return await _repository.EliminarPrestamo(id);
        }
    }
}
