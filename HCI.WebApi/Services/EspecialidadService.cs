using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.HciDbContext;
using Microsoft.EntityFrameworkCore;
using HCI.WebApi.Services.DTO;

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
        public async Task<Especialidad> CrearEspecialidadAsync(EspecialidadDTO especialidad)
        {
            var newEspecialidad = new Especialidad
            {
                NombreEspecialidad = especialidad.NombreEspecialidad,
                Descripcion = especialidad.Descripcion
            };
            _context.Especialidades.Add(newEspecialidad);
            await _context.SaveChangesAsync();
            return newEspecialidad;
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
        public async Task<bool> ActualizarEspecialidadAsync(EspecialidadDTO especialidad)
        {
            var foundEspecialidad = await _context.Especialidades.FirstOrDefaultAsync(e => e.IdEspecialidad == especialidad.IdEspecialidad);
            if (foundEspecialidad == null)
            {
                throw new Exception("Especilidad not found");
            }
            foundEspecialidad.NombreEspecialidad = especialidad.NombreEspecialidad;
            foundEspecialidad.Descripcion = especialidad.Descripcion;
            _context.Especialidades.Update(foundEspecialidad);
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
