using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.HciDbContext;
using Microsoft.EntityFrameworkCore;

namespace HCI.WebApi.Services
{
    public class CitaService : ICitaService
    {
        private readonly HCIContext _context;

        public CitaService(HCIContext context)
        {
            _context = context;
        }

        // Crear una nueva Cita
        public async Task<Cita> CrearCitaAsync(Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        // Obtener todas las Citas
        public async Task<List<Cita>> ObtenerCitasAsync()
        {
            return await _context.Citas.Include(c => c.Paciente)
                                       .Include(c => c.MedicoEspecialidad)
                                       .ToListAsync();
        }

        // Obtener una Cita por ID
        public async Task<Cita> ObtenerCitaPorIdAsync(int id)
        {
            return await _context.Citas.Include(c => c.Paciente)
                                       .Include(c => c.MedicoEspecialidad)
                                       .FirstOrDefaultAsync(c => c.IdCita == id);
        }

        // Actualizar una Cita
        public async Task<bool> ActualizarCitaAsync(Cita cita)
        {
            _context.Citas.Update(cita);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Eliminar una Cita
        public async Task<bool> EliminarCitaAsync(int id)
        {
            var cita = await ObtenerCitaPorIdAsync(id);
            if (cita == null) return false;

            _context.Citas.Remove(cita);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
