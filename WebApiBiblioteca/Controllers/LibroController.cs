using Dominio.Dtos.LibroDto;
using Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositorio.Data;
using Servicio;
using Servicio.Interfaces;
using System.Globalization;

namespace WebApiBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        private readonly AppDbContext _context;


        public LibroController(ILibroService libroService, AppDbContext context)
        {
            _libroService = libroService;
            _context = context;
        }

        //Get
        [HttpGet]
        public async Task<ActionResult> ConsultarLibros()
        {
            var libros = await _libroService.ConsultarLibros();

            return Ok(_libroService.ConsultarLibros());
        }


        //Get id
        [HttpGet("{id}")]
        public ActionResult<Libro> Consultar(int id)
        {
            return Ok(_libroService.Consultar(id));
        }

        [HttpPost]
        public ActionResult Crear([FromBody] CrearLibroDto crearLibroDto)
        {

            if (!String.IsNullOrEmpty(crearLibroDto.Titulo)
                || !String.IsNullOrEmpty(crearLibroDto.Autores)
                || !String.IsNullOrEmpty(crearLibroDto.Editorial)
                || !String.IsNullOrEmpty(crearLibroDto.Descripcion)
                || !String.IsNullOrEmpty(crearLibroDto.Idioma)
                )

            {
                var libroCreado = _libroService.Registrar(crearLibroDto);
                if (libroCreado == null)
                {
                    return BadRequest($"Ya existe un producto de nombre {crearLibroDto.Descripcion}");
                }

                return Ok(libroCreado);
            }
        
            else {

                return BadRequest("Error en los datos de entrada");
                 }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
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
                var respuesta = await _libroService.EliminarLibro(id);

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

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }


    }
}
