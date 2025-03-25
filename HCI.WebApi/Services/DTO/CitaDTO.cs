namespace HCI.WebApi.Services.DTO
{
    public class CitaDTO
    {
        public int? IdCita { get; set; }
        public int IdUsuario { get; set; }
        public int IdMedicoEspecialidad { get; set; }
        public DateTime FechaCita { get; set; }
        public string Estado { get; set; }  // 'pendiente', 'atendida', 'cancelada', 'no_efectuada'
    }
}
