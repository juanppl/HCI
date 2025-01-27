namespace HCI.WebApi.HciDbContext.Models
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public int IdMedicoEspecialidad { get; set; }
        public DateTime FechaTurno { get; set; }
        public string Estado { get; set; }  // 'disponible', 'reservado', 'ocupado'

        public MedicoEspecialidad MedicoEspecialidad { get; set; }
    }
}
