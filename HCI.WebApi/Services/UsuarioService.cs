using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.HciDbContext;
using Microsoft.EntityFrameworkCore;

namespace HCI.WebApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HCIContext _context;

        public UsuarioService(HCIContext context)
        {
            _context = context;
        }

        // Crear un nuevo Usuario
        public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        // Obtener todos los Usuarios
        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return await _context.Usuarios.Include(u => u.Rol).ToListAsync();
        }

        // Obtener un Usuario por ID
        public async Task<Usuario> ObtenerUsuarioPorIdAsync(int id)
        {
            return await _context.Usuarios.Include(u => u.Rol)
                                           .FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        // Actualizar un Usuario
        public async Task<bool> ActualizarUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Eliminar un Usuario
        public async Task<bool> EliminarUsuarioAsync(int id)
        {
            var usuario = await ObtenerUsuarioPorIdAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
