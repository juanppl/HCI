using HCI.WebApi.HciDbContext.Models;

namespace HCI.WebApi.Services
{
    public interface IRolService
    {
        Task<Rol> CrearRolAsync(Rol rol);
        Task<List<Rol>> ObtenerRolesAsync();
        Task<Rol> ObtenerRolPorIdAsync(int id);
        Task<bool> ActualizarRolAsync(Rol rol);
        Task<bool> EliminarRolAsync(int id);
    }
}
