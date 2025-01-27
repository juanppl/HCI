using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoEspecialidadController : ControllerBase
    {
        private readonly IMedicoEspecialidadService _medicoEspecialidadService;

        public MedicoEspecialidadController(IMedicoEspecialidadService medicoEspecialidadService)
        {
            _medicoEspecialidadService = medicoEspecialidadService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearMedicoEspecialidad([FromBody] MedicoEspecialidad medicoEspecialidad)
        {
            if (medicoEspecialidad == null) return BadRequest("El medico especialidad no puede ser nulo.");

            var nuevoMedicoEspecialidad = await _medicoEspecialidadService.CrearMedicoEspecialidadAsync(medicoEspecialidad);
            return CreatedAtAction(nameof(ObtenerMedicoEspecialidad), new { id = nuevoMedicoEspecialidad.IdMedicoEspecialidad }, nuevoMedicoEspecialidad);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerMedicoEspecialidad()
        {
            var MedicoEspecialidad = await _medicoEspecialidadService.ObtenerMedicoEspecialidadAsync();
            return Ok(MedicoEspecialidad);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerMedicoEspecialidad(int id)
        {
            var medicoEspecialidad = await _medicoEspecialidadService.ObtenerMedicoEspecialidadPorIdAsync(id);
            if (medicoEspecialidad == null) return NotFound($"Medico especialidad con id {id} no encontrada.");
            return Ok(medicoEspecialidad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMedicoEspecialidad(int id, [FromBody] MedicoEspecialidad medicoEspecialidad)
        {
            if (medicoEspecialidad == null || id != medicoEspecialidad.IdMedicoEspecialidad) return BadRequest("Los datos del medico especialidad son incorrectos.");

            var actualizado = await _medicoEspecialidadService.ActualizarMedicoEspecialidadAsync(medicoEspecialidad);
            if (!actualizado) return NotFound($"Medico especialidad con id {id} no encontrado.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarMedicoEspecialidad(int id)
        {
            var eliminado = await _medicoEspecialidadService.EliminarMedicoEspecialidadAsync(id);
            if (!eliminado) return NotFound($"Medico especialidad con id {id} no encontrada.");

            return NoContent();
        }
    }
}
