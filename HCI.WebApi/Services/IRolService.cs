using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.Services.DTO;

namespace HCI.WebApi.Services
{
    public interface IRolService
    {
        Task<Rol> CrearRolAsync(RolDTO rol);
        Task<List<Rol>> ObtenerRolesAsync();
        Task<Rol> ObtenerRolPorIdAsync(int id);
        Task<bool> ActualizarRolAsync(RolDTO rol);
        Task<bool> EliminarRolAsync(int id);
    }
}
