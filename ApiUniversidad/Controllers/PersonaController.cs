using ApiUniversidad.Controllers;
using ApiUniversidad.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
namespace API.Controllers
{
    public class PersonaController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PersonaController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
        {
            var Persona = await _unitOfWork.Personas.GetAllAsync();
            return _mapper.Map<List<PersonaDto>>(Persona);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var Persona = await _unitOfWork.Personas.GetByIdAsync(id);
            return _mapper.Map<PersonaDto>(Persona);
        }

        [HttpGet("consulta1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AlumnoDto>>> GetConsult1()
        {
            var Persona = await _unitOfWork.Personas.GetConsulta1();
            return _mapper.Map<List<AlumnoDto>>(Persona);
        }

        [HttpGet("consulta2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AlumnoDto>>> GetConsult2()
        {
            var Persona = await _unitOfWork.Personas.GetConsulta2();
            return _mapper.Map<List<AlumnoDto>>(Persona);
        }
        
        [HttpGet("consulta3")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AlumnoDto>>> GetConsult3()
        {
            var Persona = await _unitOfWork.Personas.GetConsulta3();
            return _mapper.Map<List<AlumnoDto>>(Persona);
        }
        
        [HttpGet("consulta4")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfeDto>>> GetConsult4()
        {
            var Persona = await _unitOfWork.Personas.GetConsulta4();
            return _mapper.Map<List<ProfeDto>>(Persona);
        }
        
        [HttpGet("consulta6")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AlumnaDto>>> GetConsult6()
        {
            var Persona = await _unitOfWork.Personas.GetConsulta6();
            return _mapper.Map<List<AlumnaDto>>(Persona);
        }
        
        [HttpGet("consulta11")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AlumnoDto>>> GetConsult11()
        {
            var Persona = await _unitOfWork.Personas.GetConsulta11();
            return _mapper.Map<List<AlumnoDto>>(Persona);
        }
        
        [HttpGet("consulta17")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> GetConsult17()
        {
            var Persona = await _unitOfWork.Personas.GetConsulta17();
            return Ok(Persona);
        }
        
        [HttpGet("consulta18")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> GetConsult18()
        {
            var Persona = await _unitOfWork.Personas.GetConsulta18();
            return Ok(Persona);
        }
        
        [HttpGet("consulta26")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> GetConsult26()
        {
            var Persona = await _unitOfWork.Personas.GetConsulta26();
            return _mapper.Map<PersonaDto>(Persona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Persona>> Post(PersonaDto PersonaDto)
        {
            var Persona = _mapper.Map<Persona>(PersonaDto);
            _unitOfWork.Personas.Add(Persona);
            await _unitOfWork.SaveAsync();

            if (Persona == null)
            {
                return BadRequest();
            }
            Persona.Id = Persona.Id;
            return CreatedAtAction(nameof(Post), new { id = Persona.Id }, Persona);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody]PersonaDto PersonaDto)
        {
            if (PersonaDto == null)
            {
                return NotFound();
            }
            var Persona = _mapper.Map<Persona>(PersonaDto);
            _unitOfWork.Personas.Update(Persona);
            await _unitOfWork.SaveAsync();
            return PersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Delete(int id)
        {
            var Persona = await _unitOfWork.Personas.GetByIdAsync(id);
            if (Persona == null)
            {
                return NotFound();
            }
            _unitOfWork.Personas.Remove(Persona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}