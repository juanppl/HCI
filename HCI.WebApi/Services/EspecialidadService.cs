using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.HciDbContext;
using Microsoft.EntityFrameworkCore;

namespace HCI.WebApi.Services
{
    public class EspecialidadService : IEspecialidadService
    {
        private readonly HCIContext _context;

        public EspecialidadService(HCIContext context)
        {
            _context = context;
        }

        // Crear una nueva Especialidad
        public async Task<Especialidad> CrearEspecialidadAsync(Especialidad especialidad)
        {
            _context.Especialidades.Add(especialidad);
            await _context.SaveChangesAsync();
            return especialidad;
        }

        // Obtener todas las Especialidades
        public async Task<List<Especialidad>> ObtenerEspecialidadesAsync()
        {
            return await _context.Especialidades.ToListAsync();
        }

        // Obtener una Especialidad por ID
        public async Task<Especialidad> ObtenerEspecialidadPorIdAsync(int id)
        {
            return await _context.Especialidades.FirstOrDefaultAsync(e => e.IdEspecialidad == id);
        }

        // Actualizar una Especialidad
        public async Task<bool> ActualizarEspecialidadAsync(Especialidad especialidad)
        {
            _context.Especialidades.Update(especialidad);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Eliminar una Especialidad
        public async Task<bool> EliminarEspecialidadAsync(int id)
        {
            var especialidad = await ObtenerEspecialidadPorIdAsync(id);
            if (especialidad == null) return false;

            _context.Especialidades.Remove(especialidad);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
