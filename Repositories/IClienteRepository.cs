using AppAPI.Model;

namespace AppAPI.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> Get();
        Task<Cliente> Get(int id);
        Task<Cliente> Create(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(int id);
    }
}
