namespace HCI.WebApi.HciDbContext.Models
{
    public class MedicoEspecialidad
    {
        public int IdMedicoEspecialidad { get; set; }
        public int IdUsuario { get; set; }
        public int IdEspecialidad { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Usuario Usuario { get; set; }
        public Especialidad Especialidad { get; set; }
        public ICollection<Cita> Citas { get; set; }
        public ICollection<Turno> Turnos { get; set; }
    }
}
