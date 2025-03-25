using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.HciDbContext;
using Microsoft.EntityFrameworkCore;
using HCI.WebApi.Services.DTO;
using AutoMapper;

namespace HCI.WebApi.Services
{
    public class CitaService : ICitaService
    {
        private readonly HCIContext _context;
        private readonly IMapper _mapper;

        public CitaService(HCIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Crear una nueva Cita
        public async Task<Cita> CrearCitaAsync(CitaDTO cita)
        {
            var newCita = new Cita
            {
                IdUsuario = cita.IdUsuario,
                IdMedicoEspecialidad = cita.IdMedicoEspecialidad,
                FechaCita = cita.FechaCita,
                Estado = "Pendiente",
            };
            _context.Citas.Add(newCita);
            await _context.SaveChangesAsync();
            return newCita;
        }

        // Obtener todas las Citas
        public async Task<List<Cita>> ObtenerCitasAsync()
        {
            return await _context.Citas.Include(c => c.Paciente)
                                       .Include(c => c.MedicoEspecialidad)
                                       .ToListAsync();
        }

        // Obtener una Cita por ID
        public async Task<List<ObtenerCitaOutput>> ObtenerCitaPorIdAsync(int id)
        {
            var userAppointments = await _context.Citas
                .Where(c => c.IdUsuario == id)
                .Include(c => c.Paciente)
                .Include(c => c.MedicoEspecialidad).ThenInclude(m => m.Especialidad)
                .Include(c => c.MedicoEspecialidad).ThenInclude(m => m.Usuario)
                .ToListAsync();

            return _mapper.Map<List<ObtenerCitaOutput>>(userAppointments);
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
            var cita = await _context.Citas.FirstOrDefaultAsync(c => c.IdCita == id);
            if (cita == null) return false;

            _context.Citas.Remove(cita);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }

    public class ObtenerCitaOutput
    {
        public int IdCita { get; set; }
        public int IdUsuario { get; set; }
        public int IdMedicoEspecialidad { get; set; }
        public DateTime FechaCita { get; set; }
        public string Estado { get; set; }
        public UsuarioCitaOutput Paciente { get; set; }
        public MedicoEspecialidadOuput MedicoEspecialidad { get; set; }
    }

    public class UsuarioCitaOutput
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }

    public class MedicoEspecialidadOuput {
        public int IdMedicoEspecialidad { get; set; }
        public int IdUsuario { get; set; }
        public int IdEspecialidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public UsuarioCitaOutput Usuario { get; set; }
        public EspecialidadDTO Especialidad { get; set; }
    }
}
