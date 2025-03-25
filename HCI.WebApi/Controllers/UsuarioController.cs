using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.Services;
using HCI.WebApi.Services.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioDTO usuario)
        {
            if (usuario == null) return BadRequest("El usuario no puede ser nulo.");

            var user = new Usuario
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Telefono = usuario.Telefono,
                Direccion = usuario.Direccion,
                Email = usuario.Email,
                IdRol = usuario.IdRol,
                FechaRegistro = DateTime.Now,
            };

            var nuevoUsuario = await _usuarioService.CrearUsuarioAsync(user);
            return CreatedAtAction(nameof(ObtenerUsuario), new { id = nuevoUsuario.IdUsuario }, nuevoUsuario);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorIdAsync(id);
            if (usuario == null) return NotFound($"Usuario con id {id} no encontrado.");
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] UsuarioDTO usuario)
        {
            if (usuario == null || id != usuario.IdUsuario) return BadRequest("Los datos del usuario son incorrectos.");

            var user = new Usuario
            {
                IdUsuario = (int)usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Telefono = usuario.Telefono,
                Direccion = usuario.Direccion,
                Email = usuario.Email,
                IdRol = usuario.IdRol,
                FechaRegistro = DateTime.Now,
            };

            var actualizado = await _usuarioService.ActualizarUsuarioAsync(user);
            if (!actualizado) return NotFound($"Usuario con id {id} no encontrado.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var eliminado = await _usuarioService.EliminarUsuarioAsync(id);
            if (!eliminado) return NotFound($"Usuario con id {id} no encontrado.");

            return NoContent();
        }
    }
}
