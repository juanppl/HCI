using HCI.WebApi.HciDbContext.Models;

namespace HCI.WebApi.Services.DTO
{
    public class UsuarioDTO
    {
        public int? IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int IdRol { get; set; }
        public ICollection<MedicoEspecialidadDTO> MedicoEspecialidad { get; set; }
    }
}
