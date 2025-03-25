namespace HCI.WebApi.HciDbContext.Models
{
    public class Cita
    {
        public int IdCita { get; set; }
        public int IdUsuario { get; set; }
        public int IdMedicoEspecialidad { get; set; }
        public DateTime FechaCita { get; set; }
        public string Estado { get; set; }  // 'pendiente', 'atendida', 'cancelada', 'no_efectuada'
        public string? Motivo { get; set; }

        public Usuario Paciente { get; set; }
        public MedicoEspecialidad MedicoEspecialidad { get; set; }
    }
}
