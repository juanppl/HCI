using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ICitaService _citaService;

        public CitaController(ICitaService citaService)
        {
            _citaService = citaService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCita([FromBody] Cita cita)
        {
            if (cita == null) return BadRequest("La cita no puede ser nula.");

            var nuevaCita = await _citaService.CrearCitaAsync(cita);
            return CreatedAtAction(nameof(ObtenerCita), new { id = nuevaCita.IdCita }, nuevaCita);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCitas()
        {
            var citas = await _citaService.ObtenerCitasAsync();
            return Ok(citas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCita(int id)
        {
            var cita = await _citaService.ObtenerCitaPorIdAsync(id);
            if (cita == null) return NotFound($"Cita con id {id} no encontrada.");
            return Ok(cita);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCita(int id, [FromBody] Cita cita)
        {
            if (cita == null || id != cita.IdCita) return BadRequest("Los datos de la cita son incorrectos.");

            var actualizado = await _citaService.ActualizarCitaAsync(cita);
            if (!actualizado) return NotFound($"Cita con id {id} no encontrada.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCita(int id)
        {
            var eliminado = await _citaService.EliminarCitaAsync(id);
            if (!eliminado) return NotFound($"Cita con id {id} no encontrada.");

            return NoContent();
        }
    }
}
