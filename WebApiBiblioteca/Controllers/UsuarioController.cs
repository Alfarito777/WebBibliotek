using Dominio.Dtos.LibroDto;
using Dominio.Dtos.UsuarioDto;
using Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositorio.Data;
using Servicio.Interfaces;

namespace WebApiBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly AppDbContext _context;


        public UsuarioController(IUsuarioService usuarioService, AppDbContext context)
        {
            _usuarioService = usuarioService;
            _context = context;
        }


        //Get
        [HttpGet]
        public async Task<ActionResult> ConsultarUsuarios()
        {
            var usuarios = await _usuarioService.ConsultarUsuarios();

            return Ok(_usuarioService.ConsultarUsuarios());
        }


        //Get id
        [HttpGet("{id}")]
        public ActionResult<Usuario> Consultar(int id)
        {
            return Ok(_usuarioService.Consultar(id));
        }

        [HttpPost]
        public ActionResult Crear([FromBody] CrearUsuarioDto crearUsuarioDto)
        {
      
            var usuarioCreado = _usuarioService.Registrar(crearUsuarioDto);
            if (usuarioCreado == null)
            {
                return BadRequest($"Error en los datos de entrada{crearUsuarioDto.Descripcion}");
            }
            else
            {
                return Ok(usuarioCreado);
            }        
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var respuesta = await _usuarioService.EliminarUsuario(id);

                if (respuesta == false)
                {
                    return BadRequest("Ocurrió un error en la creación");
                }
                else
                {
                    return Ok("Eliminación exitosa");
                }


            }
            catch
            {
                return Ok();
            }
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
