using AppAPI.Context;
using AppAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> Create(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task Delete(int id)
        {
            var usuarioToDelete = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuarioToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> Get(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task Update(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
