using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.HciDbContext;
using Microsoft.EntityFrameworkCore;

namespace HCI.WebApi.Services
{
    public class MedicoEspecialidadService : IMedicoEspecialidadService
    {
        private readonly HCIContext _context;

        public MedicoEspecialidadService(HCIContext context)
        {
            _context = context;
        }

        // Crear un nuevo MedicoEspecialidad
        public async Task<MedicoEspecialidad> CrearMedicoEspecialidadAsync(MedicoEspecialidad medicoEspecialidad)
        {
            _context.MedicoEspecialidad.Add(medicoEspecialidad);
            await _context.SaveChangesAsync();
            return medicoEspecialidad;
        }

        // Obtener todos los MedicoEspecialidad
        public async Task<List<MedicoEspecialidad>> ObtenerMedicoEspecialidadAsync()
        {
            return await _context.MedicoEspecialidad.Include(me => me.Usuario)
                                                      .Include(me => me.Especialidad)
                                                      .ToListAsync();
        }

        // Obtener un MedicoEspecialidad por ID
        public async Task<MedicoEspecialidad> ObtenerMedicoEspecialidadPorIdAsync(int id)
        {
            return await _context.MedicoEspecialidad.Include(me => me.Usuario)
                                                      .Include(me => me.Especialidad)
                                                      .FirstOrDefaultAsync(me => me.IdMedicoEspecialidad == id);
        }

        // Actualizar un MedicoEspecialidad
        public async Task<bool> ActualizarMedicoEspecialidadAsync(MedicoEspecialidad medicoEspecialidad)
        {
            _context.MedicoEspecialidad.Update(medicoEspecialidad);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Eliminar un MedicoEspecialidad
        public async Task<bool> EliminarMedicoEspecialidadAsync(int id)
        {
            var medicoEspecialidad = await ObtenerMedicoEspecialidadPorIdAsync(id);
            if (medicoEspecialidad == null) return false;

            _context.MedicoEspecialidad.Remove(medicoEspecialidad);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
