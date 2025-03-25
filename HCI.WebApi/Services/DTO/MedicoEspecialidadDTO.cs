using HCI.WebApi.HciDbContext.Models;

namespace HCI.WebApi.Services.DTO
{
    public class MedicoEspecialidadDTO
    {
        public int IdMedicoEspecialidad { get; set; }
        public int IdUsuario { get; set; }
        public int IdEspecialidad { get; set; }
        public EspecialidadDTO Especialidad { get; set; }
        //public UsuarioDTO? Usuario { get; set; }
    }
}
