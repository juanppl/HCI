using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoService _turnoService;

        public TurnoController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTurno([FromBody] Turno turno)
        {
            if (turno == null) return BadRequest("El turno no puede ser nulo.");

            var nuevoTurno = await _turnoService.CrearTurnoAsync(turno);
            return CreatedAtAction(nameof(ObtenerTurno), new { id = nuevoTurno.IdTurno }, nuevoTurno);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTurnos()
        {
            var turnos = await _turnoService.ObtenerTurnosAsync();
            return Ok(turnos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTurno(int id)
        {
            var turno = await _turnoService.ObtenerTurnoPorIdAsync(id);
            if (turno == null) return NotFound($"Turno con id {id} no encontrado.");
            return Ok(turno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTurno(int id, [FromBody] Turno turno)
        {
            if (turno == null || id != turno.IdTurno) return BadRequest("Los datos del turno son incorrectos.");

            var actualizado = await _turnoService.ActualizarTurnoAsync(turno);
            if (!actualizado) return NotFound($"Turno con id {id} no encontrado.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTurno(int id)
        {
            var eliminado = await _turnoService.EliminarTurnoAsync(id);
            if (!eliminado) return NotFound($"Turno con id {id} no encontrado.");

            return NoContent();
        }
    }
}
