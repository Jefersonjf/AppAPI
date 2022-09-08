using AppAPI.Model;

namespace AppAPI.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> Get();
        Task<Usuario> Get(int id);
        Task<Usuario> Create(Usuario usuario);
        Task Update(Usuario usuario);
        Task Delete(int id);
    }
}
