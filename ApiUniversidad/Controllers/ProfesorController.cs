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
    public class ProfesorController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProfesorController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProfesorDto>>> Get()
        {
            var Profesor = await _unitOfWork.Profesores.GetAllAsync();
            return _mapper.Map<List<ProfesorDto>>(Profesor);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProfesorDto>> Get(int id)
        {
            var Profesor = await _unitOfWork.Profesores.GetByIdAsync(id);
            return _mapper.Map<ProfesorDto>(Profesor);
        }

        [HttpGet("consulta8")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetConsult8()
        {
            var Persona = await _unitOfWork.Profesores.GetConsulta8();
            return Ok(Persona);
        }
        
        [HttpGet("consulta12")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetConsult12()
        {
            var Persona = await _unitOfWork.Profesores.GetConsulta12();
            return Ok(Persona);
        }
        
        [HttpGet("consulta14")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetConsult14()
        {
            var Persona = await _unitOfWork.Profesores.GetConsulta14();
            return Ok(Persona);
        }
        
        [HttpGet("consulta25")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetConsult25()
        {
            var Persona = await _unitOfWork.Profesores.GetConsulta25();
            return Ok(Persona);
        }
        
        [HttpGet("consulta27")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetConsult27()
        {
            var Persona = await _unitOfWork.Profesores.GetConsulta27();
            return Ok(Persona);
        }
        [HttpGet("consulta29")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetConsult29()
        {
            var Persona = await _unitOfWork.Profesores.GetConsulta29();
            return Ok(Persona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Profesor>> Post(ProfesorDto ProfesorDto)
        {
            var Profesor = _mapper.Map<Profesor>(ProfesorDto);
            _unitOfWork.Profesores.Add(Profesor);
            await _unitOfWork.SaveAsync();

            if (Profesor == null)
            {
                return BadRequest();
            }
            Profesor.Id = Profesor.Id;
            return CreatedAtAction(nameof(Post), new { id = Profesor.Id }, Profesor);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProfesorDto>> Put(int id, [FromBody]ProfesorDto ProfesorDto)
        {
            if (ProfesorDto == null)
            {
                return NotFound();
            }
            var Profesor = _mapper.Map<Profesor>(ProfesorDto);
            _unitOfWork.Profesores.Update(Profesor);
            await _unitOfWork.SaveAsync();
            return ProfesorDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProfesorDto>> Delete(int id)
        {
            var Profesor = await _unitOfWork.Profesores.GetByIdAsync(id);
            if (Profesor == null)
            {
                return NotFound();
            }
            _unitOfWork.Profesores.Remove(Profesor);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}