using HCI.WebApi.HciDbContext.Models;

namespace HCI.WebApi.Services.DTO
{
    public class TurnoDTO
    {
        public int? IdTurno { get; set; }
        public int IdMedicoEspecialidad { get; set; }
        public DateTime FechaTurno { get; set; }
        public DateTime FechaTurnoFin { get; set; }
        public MedicoEspecialidadDTO? MedicoEspecialidad { get; set; }
    }
}
