using AutoMapper;
using Dominio.Dtos.LibroDto;
using Dominio.Dtos.PrestamoDto;
using Dominio.Dtos.UsuarioDto;
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
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Usuario>> ConsultarUsuarios()
        {
            return await _repository.ConsultarUsuarios();
        }

        public Usuario Consultar(int id)
        {
            return _repository.Consultar(id);
        }


        public UsuarioCreadoDto Registrar(CrearUsuarioDto dto)
        {
            var existe = _repository.Consultar(dto.Descripcion);

            if (existe is null)
            {
                var usuario = _mapper.Map<Usuario>(dto);

                _repository.Registrar(usuario);

                var usuarioCreado = _mapper.Map<UsuarioCreadoDto>(usuario);

                return _mapper.Map<UsuarioCreadoDto>(usuario);
                return usuarioCreado;

            }

            return null;
        }






        public async Task<bool> EditarUsuario(Usuario usuario)
        {
            return await _repository.EditarUsuario(usuario);
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            return await _repository.EliminarUsuario(id);
        }
    }
}
