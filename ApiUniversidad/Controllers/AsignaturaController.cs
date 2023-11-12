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
    public class AsignaturaController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AsignaturaController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaDto>>> Get()
        {
            var Asignatura = await _unitOfWork.Asignaturas.GetAllAsync();
            return _mapper.Map<List<AsignaturaDto>>(Asignatura);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AsignaturaDto>> Get(int id)
        {
            var Asignatura = await _unitOfWork.Asignaturas.GetByIdAsync(id);
            return _mapper.Map<AsignaturaDto>(Asignatura);
        }

        [HttpGet("consulta5")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaPerDto>>> GetConsult5()
        {
            var Asignatura = await _unitOfWork.Asignaturas.GetConsulta5();
            return _mapper.Map<List<AsignaturaPerDto>>(Asignatura);
        }
        
        [HttpGet("consulta7")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaPerDto>>> GetConsult7()
        {
            var Asignatura = await _unitOfWork.Asignaturas.GetConsulta7();
            return _mapper.Map<List<AsignaturaPerDto>>(Asignatura);
        }
        
        [HttpGet("consulta9")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetConsult9()
        {
            var Asignatura = await _unitOfWork.Asignaturas.GetConsulta9();
            return Ok(Asignatura);
        }

        [HttpGet("consulta15")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaDto>>> GetConsult15()
        {
            var Asignatura = await _unitOfWork.Asignaturas.GetConsulta15();
            return _mapper.Map<List<AsignaturaDto>>(Asignatura);
        }
        
        [HttpGet("consulta30")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AsignaturaDto>>> GetConsult30()
        {
            var Asignatura = await _unitOfWork.Asignaturas.GetConsulta30();
            return _mapper.Map<List<AsignaturaDto>>(Asignatura);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Asignatura>> Post(AsignaturaDto AsignaturaDto)
        {
            var Asignatura = _mapper.Map<Asignatura>(AsignaturaDto);
            _unitOfWork.Asignaturas.Add(Asignatura);
            await _unitOfWork.SaveAsync();

            if (Asignatura == null)
            {
                return BadRequest();
            }
            Asignatura.Id = Asignatura.Id;
            return CreatedAtAction(nameof(Post), new { id = Asignatura.Id }, Asignatura);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AsignaturaDto>> Put(int id, [FromBody]AsignaturaDto AsignaturaDto)
        {
            if (AsignaturaDto == null)
            {
                return NotFound();
            }
            var Asignatura = _mapper.Map<Asignatura>(AsignaturaDto);
            _unitOfWork.Asignaturas.Update(Asignatura);
            await _unitOfWork.SaveAsync();
            return AsignaturaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AsignaturaDto>> Delete(int id)
        {
            var Asignatura = await _unitOfWork.Asignaturas.GetByIdAsync(id);
            if (Asignatura == null)
            {
                return NotFound();
            }
            _unitOfWork.Asignaturas.Remove(Asignatura);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}