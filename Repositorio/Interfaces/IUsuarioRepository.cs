using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IUsuarioRepository
    {
        bool Registrar(Usuario usuario);
        Task<List<Usuario>> ConsultarUsuarios();
        Usuario Consultar(int id);
        Usuario Consultar(string descripcion);
        Task<bool> EditarUsuario(Usuario usuario);
        Task<bool> EliminarUsuario(int id);
    }
}
