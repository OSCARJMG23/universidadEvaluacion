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
    public class CursoEscolarController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CursoEscolarController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CursoEscolarDto>>> Get()
        {
            var CursoEscolar = await _unitOfWork.Cursos.GetAllAsync();
            return _mapper.Map<List<CursoEscolarDto>>(CursoEscolar);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CursoEscolarDto>> Get(int id)
        {
            var CursoEscolar = await _unitOfWork.Cursos.GetByIdAsync(id);
            return _mapper.Map<CursoEscolarDto>(CursoEscolar);
        }

        [HttpGet("consulta24")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<object>>> GetConsult24()
        {
            var CursoEscolar = await _unitOfWork.Cursos.GetConsulta24();
            return Ok(CursoEscolar);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CursoEscolar>> Post(CursoEscolarDto CursoEscolarDto)
        {
            var CursoEscolar = _mapper.Map<CursoEscolar>(CursoEscolarDto);
            _unitOfWork.Cursos.Add(CursoEscolar);
            await _unitOfWork.SaveAsync();

            if (CursoEscolar == null)
            {
                return BadRequest();
            }
            CursoEscolar.Id = CursoEscolar.Id;
            return CreatedAtAction(nameof(Post), new { id = CursoEscolar.Id }, CursoEscolar);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CursoEscolarDto>> Put(int id, [FromBody]CursoEscolarDto CursoEscolarDto)
        {
            if (CursoEscolarDto == null)
            {
                return NotFound();
            }
            var CursoEscolar = _mapper.Map<CursoEscolar>(CursoEscolarDto);
            _unitOfWork.Cursos.Update(CursoEscolar);
            await _unitOfWork.SaveAsync();
            return CursoEscolarDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CursoEscolarDto>> Delete(int id)
        {
            var CursoEscolar = await _unitOfWork.Cursos.GetByIdAsync(id);
            if (CursoEscolar == null)
            {
                return NotFound();
            }
            _unitOfWork.Cursos.Remove(CursoEscolar);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}