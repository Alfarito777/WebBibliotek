using Dominio.Dtos.LibroDto;
using Dominio.Dtos.UsuarioDto;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioCreadoDto Registrar(CrearUsuarioDto dto);
        Usuario Consultar(int id);
        Task<List<Usuario>> ConsultarUsuarios();
        Task<bool> EliminarUsuario(int id);
        Task<bool> EditarUsuario(Usuario usuario);
    }
}
