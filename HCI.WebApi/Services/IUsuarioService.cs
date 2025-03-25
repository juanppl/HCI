using HCI.WebApi.HciDbContext.Models;
using HCI.WebApi.Services.DTO;
using System.Threading.Tasks;

namespace HCI.WebApi.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> CrearUsuarioAsync(Usuario usuario);
        Task<List<UsuarioDTO>> ObtenerUsuariosAsync();
        Task<Usuario> ObtenerUsuarioPorIdAsync(int id);
        Task<bool> ActualizarUsuarioAsync(Usuario usuario);
        Task<bool> EliminarUsuarioAsync(int id);
    }
}
