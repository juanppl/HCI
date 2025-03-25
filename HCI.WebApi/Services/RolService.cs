using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.HciDbContext;
using Microsoft.EntityFrameworkCore;
using HCI.WebApi.Services.DTO;

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
        public async Task<Rol> CrearRolAsync(RolDTO rol)
        {
            var newRol = new Rol
            {
                NombreRol = rol.NombreRol,
                Descripcion = rol.Descripcion,
            };
            _context.Roles.Add(newRol);
            await _context.SaveChangesAsync();
            return newRol;
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
        public async Task<bool> ActualizarRolAsync(RolDTO rol)
        {
            var foundRol = await _context.Roles.FirstOrDefaultAsync(r => r.IdRol == rol.IdRol);
            if (foundRol == null) {
                throw new Exception("No Rol found");
            }
            foundRol.NombreRol = rol.NombreRol;
            foundRol.Descripcion = rol.Descripcion;
            _context.Roles.Update(foundRol);
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
