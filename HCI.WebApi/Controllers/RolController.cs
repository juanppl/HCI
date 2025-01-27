using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearRol([FromBody] Rol rol)
        {
            if (rol == null) return BadRequest("El rol no puede ser nulo.");

            var nuevoRol = await _rolService.CrearRolAsync(rol);
            return CreatedAtAction(nameof(ObtenerRol), new { id = nuevoRol.IdRol }, nuevoRol);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerRoles()
        {
            var roles = await _rolService.ObtenerRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerRol(int id)
        {
            var rol = await _rolService.ObtenerRolPorIdAsync(id);
            if (rol == null) return NotFound($"Rol con id {id} no encontrado.");
            return Ok(rol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarRol(int id, [FromBody] Rol rol)
        {
            if (rol == null || id != rol.IdRol) return BadRequest("Los datos del rol son incorrectos.");

            var actualizado = await _rolService.ActualizarRolAsync(rol);
            if (!actualizado) return NotFound($"Rol con id {id} no encontrado.");

            return NoContent(); // Indica que la actualización fue exitosa pero no hay contenido en la respuesta
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRol(int id)
        {
            var eliminado = await _rolService.EliminarRolAsync(id);
            if (!eliminado) return NotFound($"Rol con id {id} no encontrado.");

            return NoContent(); // Indica que la eliminación fue exitosa
        }
    }
}
