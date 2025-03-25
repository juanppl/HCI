using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.Services;
using HCI.WebApi.Services.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly IEspecialidadService _especialidadService;

        public EspecialidadController(IEspecialidadService especialidadService)
        {
            _especialidadService = especialidadService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearEspecialidad([FromBody] EspecialidadDTO especialidad)
        {
            if (especialidad == null) return BadRequest("La especialidad no puede ser nula.");

            var nuevaEspecialidad = await _especialidadService.CrearEspecialidadAsync(especialidad);
            return CreatedAtAction(nameof(ObtenerEspecialidad), new { id = nuevaEspecialidad.IdEspecialidad }, nuevaEspecialidad);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerEspecialidades()
        {
            var especialidades = await _especialidadService.ObtenerEspecialidadesAsync();
            return Ok(especialidades);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerEspecialidad(int id)
        {
            var especialidad = await _especialidadService.ObtenerEspecialidadPorIdAsync(id);
            if (especialidad == null) return NotFound($"Especialidad con id {id} no encontrada.");
            return Ok(especialidad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarEspecialidad(int id, [FromBody] EspecialidadDTO especialidad)
        {
            if (especialidad == null || id != especialidad.IdEspecialidad) return BadRequest("Los datos de la especialidad son incorrectos.");

            var actualizado = await _especialidadService.ActualizarEspecialidadAsync(especialidad);
            if (!actualizado) return NotFound($"Especialidad con id {id} no encontrada.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEspecialidad(int id)
        {
            var eliminado = await _especialidadService.EliminarEspecialidadAsync(id);
            if (!eliminado) return NotFound($"Especialidad con id {id} no encontrada.");

            return NoContent();
        }
    }
}
