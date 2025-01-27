namespace HCI.WebApi.HciDbContext.Models
{
    public class Especialidad
    {
        public int IdEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; }
        public string Descripcion { get; set; }

        public ICollection<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}
