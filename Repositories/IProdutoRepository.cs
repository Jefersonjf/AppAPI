using AppAPI.Model;

namespace AppAPI.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> Get();
        Task<Produto> Get(int id);
        Task<Produto> Create(Produto produto);
        Task Update(Produto produto);
        Task Delete(int id);
    }
}
