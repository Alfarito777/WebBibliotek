using AutoMapper;
using Dominio.Dtos.LibroDto;
using Dominio.Dtos.PrestamoDto;
using Dominio.Dtos.UsuarioDto;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Mapeo
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CrearLibroDto, Libro>();
            CreateMap<Libro, LibroCreadoDto>();


            CreateMap<CrearUsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioCreadoDto>();

            CreateMap<CrearPrestamoDto, Prestamo>();
            CreateMap<Prestamo, PrestamoCreadoDto>();

        }
    }
}
