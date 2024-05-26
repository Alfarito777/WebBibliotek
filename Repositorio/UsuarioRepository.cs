using Dominio.Entities;
using Repositorio.Data;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ConsultarUsuarios()
        {
            return _context.Usuarios.ToList();

        }
        public Usuario Consultar(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario Consultar(string descripcion)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Descripcion.Equals(descripcion));
        }

        public bool Registrar(Usuario usuario)
        {
            _context.Add(usuario);
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> EditarUsuario(Usuario usuario)
        {
            try
            {
                var usuarioe = await (from u in _context.Usuarios
                                    where u.Id == usuario.Id
                                    select u).FirstOrDefaultAsync();

                if (usuarioe == null) return false;

                usuarioe.Nombre = usuario.Nombre;
                usuarioe.Apellido = usuario.Apellido;
                usuarioe.Correo = usuario.Correo;
                usuarioe.FechaNacimiento = usuario.FechaNacimiento;
                usuarioe.Genero = usuario.Genero;
                usuarioe.TipoUsuario = usuario.TipoUsuario;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> EliminarUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);

                _context.Usuarios.Remove(usuario);
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
