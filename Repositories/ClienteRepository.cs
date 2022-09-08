using AppAPI.Context;
using AppAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Cliente> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;

        }

        public async Task Delete(int id)
        {
            var clienteToDelete = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clienteToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> Get(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task Update(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
