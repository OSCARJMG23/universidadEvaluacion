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
    public class DepartamentoController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartamentoController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
        {
            var Departamento = await _unitOfWork.Departamentos.GetAllAsync();
            return _mapper.Map<List<DepartamentoDto>>(Departamento);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartamentoDto>> Get(int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
            return _mapper.Map<DepartamentoDto>(Departamento);
        }

        [HttpGet("consulta10")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> GetConsult10()
        {
            var Departamento = await _unitOfWork.Departamentos.GetConsulta10();
            return _mapper.Map<List<DepartamentoDto>>(Departamento);
        }
        
        [HttpGet("consulta13")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> GetConsult13()
        {
            var Departamento = await _unitOfWork.Departamentos.GetConsulta13();
            return _mapper.Map<List<DepartamentoDto>>(Departamento);
        }
        
        [HttpGet("consulta16")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetConsult16()
        {
            var Departamento = await _unitOfWork.Departamentos.GetConsulta16();
            return Ok(Departamento);
        }
        
        [HttpGet("consulta19")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetConsult19()
        {
            var Departamento = await _unitOfWork.Departamentos.GetConsulta19();
            return Ok(Departamento);
        }
        
        [HttpGet("consulta20")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetConsult20()
        {
            var Departamento = await _unitOfWork.Departamentos.GetConsulta20();
            return Ok(Departamento);
        }
        
        [HttpGet("consulta28")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetConsult28()
        {
            var Departamento = await _unitOfWork.Departamentos.GetConsulta28();
            return Ok(Departamento);
        }

        [HttpGet("consulta31")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> GetConsult31()
        {
            var Departamento = await _unitOfWork.Departamentos.GetConsulta31();
            return _mapper.Map<List<DepartamentoDto>>(Departamento);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Departamento>> Post(DepartamentoDto DepartamentoDto)
        {
            var Departamento = _mapper.Map<Departamento>(DepartamentoDto);
            _unitOfWork.Departamentos.Add(Departamento);
            await _unitOfWork.SaveAsync();

            if (Departamento == null)
            {
                return BadRequest();
            }
            Departamento.Id = Departamento.Id;
            return CreatedAtAction(nameof(Post), new { id = Departamento.Id }, Departamento);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody]DepartamentoDto DepartamentoDto)
        {
            if (DepartamentoDto == null)
            {
                return NotFound();
            }
            var Departamento = _mapper.Map<Departamento>(DepartamentoDto);
            _unitOfWork.Departamentos.Update(Departamento);
            await _unitOfWork.SaveAsync();
            return DepartamentoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartamentoDto>> Delete(int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetByIdAsync(id);
            if (Departamento == null)
            {
                return NotFound();
            }
            _unitOfWork.Departamentos.Remove(Departamento);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}