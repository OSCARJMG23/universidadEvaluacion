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
    public class GradoController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GradoController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            _mapper = Mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<GradoDto>>> Get()
        {
            var Grado = await _unitOfWork.Grados.GetAllAsync();
            return _mapper.Map<List<GradoDto>>(Grado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GradoDto>> Get(int id)
        {
            var Grado = await _unitOfWork.Grados.GetByIdAsync(id);
            return _mapper.Map<GradoDto>(Grado);
        }

        [HttpGet("consulta21")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> GetConsult21()
        {
            var Grado = await _unitOfWork.Grados.GetConsulta21();
            return Ok(Grado);
        }
        
        [HttpGet("consulta22")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> GetConsult22()
        {
            var Grado = await _unitOfWork.Grados.GetConsulta22();
            return Ok(Grado);
        }
        
        [HttpGet("consulta23")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<object>> GetConsult23()
        {
            var Grado = await _unitOfWork.Grados.GetConsulta23();
            return Ok(Grado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Grado>> Post(GradoDto GradoDto)
        {
            var Grado = _mapper.Map<Grado>(GradoDto);
            _unitOfWork.Grados.Add(Grado);
            await _unitOfWork.SaveAsync();

            if (Grado == null)
            {
                return BadRequest();
            }
            Grado.Id = Grado.Id;
            return CreatedAtAction(nameof(Post), new { id = Grado.Id }, Grado);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GradoDto>> Put(int id, [FromBody]GradoDto GradoDto)
        {
            if (GradoDto == null)
            {
                return NotFound();
            }
            var Grado = _mapper.Map<Grado>(GradoDto);
            _unitOfWork.Grados.Update(Grado);
            await _unitOfWork.SaveAsync();
            return GradoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GradoDto>> Delete(int id)
        {
            var Grado = await _unitOfWork.Grados.GetByIdAsync(id);
            if (Grado == null)
            {
                return NotFound();
            }
            _unitOfWork.Grados.Remove(Grado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}