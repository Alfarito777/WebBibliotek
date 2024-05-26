using AutoMapper;
using Dominio.Dtos.LibroDto;
using Dominio.Entities;
using Repositorio.Interfaces;
using Servicio.Interfaces;

namespace Servicio
{
    public class LibroService: ILibroService
    {
        private readonly ILibroRepository _repository;
        private readonly IMapper _mapper;

        public LibroService(ILibroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }   

        public async Task<List<Libro>> ConsultarLibros()
        {
            return await _repository.ConsultarLibros();
        }

        public Libro Consultar(int id)
        {
            return _repository.Consultar(id);
        }

        public LibroCreadoDto Registrar(CrearLibroDto dto)
        {
            var existe = _repository.Consultar(dto.Descripcion);

            if (existe is null)
            {
                var libro = _mapper.Map<Libro>(dto);
                libro.ISBN = new Random().Next(100000, 999999);
                
                _repository.Registrar(libro);

            var libroCreado = _mapper.Map<LibroCreadoDto>(libro);

            return _mapper.Map<LibroCreadoDto>(libro);
                return libroCreado;

            }

            return null;
        }

  

        public async Task<bool> EditarLibro(Libro libro)
        {
            return await _repository.EditarLibro(libro);
        }

        public async Task<bool> EliminarLibro(int id)
        {
            return await _repository.EliminarLibro(id);
        }
    }
}
