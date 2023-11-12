using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUniversidad.Dtos;
using AutoMapper;
using Domain.Entities;

namespace ApiUniversidad.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Asignatura, AsignaturaDto>()
            .ForMember(e=> e.IdProfesor, t=>t.MapFrom(e=>e.IdProfesorFk))
            .ReverseMap();
            CreateMap<Asignatura, AsignaturaPerDto>().ReverseMap();
            CreateMap<CursoEscolar, CursoEscolarDto>().ReverseMap();
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<Grado, GradoDto>().ReverseMap();
            CreateMap<Persona, PersonaDto>().ReverseMap();
            CreateMap<Profesor, ProfesorDto>().ReverseMap();
            
            CreateMap<Persona, AlumnoDto>()
            .ForMember(t=>t.PrimerApellido, e=>e.MapFrom(t=>t.Apellido1))
            .ForMember(t=>t.SegundoApellido, e=>e.MapFrom(t=>t.Apellido2))
            .ForMember(t=>t.Nombre, e=>e.MapFrom(t=>t.Nombre));

            CreateMap<Persona, ProfeDto>()
            .ForMember(e=>e.Nif, t=>t.MapFrom(e=>e.Nif))
            .ForMember(e=>e.Nombre, t=>t.MapFrom(e=>e.Nombre))
            .ForMember(e=>e.PrimerApellido, t=>t.MapFrom(e=>e.Apellido1))
            .ForMember(e=>e.SegundoApellido, t=>t.MapFrom(e=>e.Apellido2));

            CreateMap<Profesor, ProfesorPerDto>()
            .ForMember(e=> e.PrimerApellido, t=>t.MapFrom(e=> e.Persona.Apellido1))
            .ForMember(e=> e.PrimerApellido, t=>t.MapFrom(e=> e.Persona.Apellido2))
            .ForMember(e=> e.Nombre, t=>t.MapFrom(e =>e.Persona.Nombre));

            CreateMap<Persona, AlumnaDto>()
            .ForMember(e=> e.Nombre, t=>t.MapFrom(e=>e.Nombre))
            .ForMember(e=> e.PrimerApellido, t=>t.MapFrom(e=>e.Apellido1))
            .ForMember(e=> e.SegundoApellido, t=>t.MapFrom(e=>e.Apellido2))
            .ForMember(e=> e.Sexo, t=>t.MapFrom(e=>e.Sexo));
        }
    }
}

