using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.HciDbContext;
using Microsoft.EntityFrameworkCore;

namespace HCI.WebApi.Services
{
    public class RolService : IRolService
    {
        private readonly HCIContext _context;

        public RolService(HCIContext context)
        {
            _context = context;
        }

        // Crear un nuevo Rol
        public async Task<Rol> CrearRolAsync(Rol rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        // Obtener todos los Roles
        public async Task<List<Rol>> ObtenerRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        // Obtener un Rol por ID
        public async Task<Rol> ObtenerRolPorIdAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.IdRol == id);
        }

        // Actualizar un Rol
        public async Task<bool> ActualizarRolAsync(Rol rol)
        {
            _context.Roles.Update(rol);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Eliminar un Rol
        public async Task<bool> EliminarRolAsync(int id)
        {
            var rol = await ObtenerRolPorIdAsync(id);
            if (rol == null) return false;

            _context.Roles.Remove(rol);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
