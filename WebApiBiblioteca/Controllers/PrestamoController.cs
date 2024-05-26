using Dominio.Dtos.LibroDto;
using Dominio.Dtos.PrestamoDto;
using Dominio.Dtos.UsuarioDto;
using Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositorio.Data;
using Servicio;
using Servicio.Interfaces;

namespace WebApiBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;
        private readonly AppDbContext _context;


        public PrestamoController(IPrestamoService prestamoService, AppDbContext context)
        {
            _prestamoService = prestamoService;
            _context = context;
        }

        //Get
        [HttpGet]
        public async Task<ActionResult> ConsultarPrestamos()
        {
            var prestamos = await _prestamoService.ConsultarPrestamos();

            return Ok(_prestamoService.ConsultarPrestamos());
        }


        //Get id
        [HttpGet("{id}")]
        public ActionResult<Prestamo> Consultar(int id)
        {
            return Ok(_prestamoService.Consultar(id));
        }

        [HttpPost]
        public ActionResult Crear([FromBody] CrearPrestamoDto crearPrestamoDto)
        {

            {
                var prestamoCreado = _prestamoService.Registrar(crearPrestamoDto);
                if (prestamoCreado == null)
                {
                    return BadRequest($"Error en los datos de entrada{crearPrestamoDto.Descripcion}");
                }
                else
                {
                    return Ok(prestamoCreado);
                }
                
            }
         
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrestamo(int id, Prestamo  prestamo)
        {
            if (id != prestamo.Id)
            {
                return BadRequest();
            }

            _context.Entry(prestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamoExists(id))
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
                var respuesta = await _prestamoService.EliminarPrestamo(id);

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

        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.Id == id);
        }
    }
}
