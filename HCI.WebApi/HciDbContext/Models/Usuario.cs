namespace HCI.WebApi.HciDbContext.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int IdRol { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Rol Rol { get; set; }
        public ICollection<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public ICollection<Cita> Citas { get; set; }
    }
}
