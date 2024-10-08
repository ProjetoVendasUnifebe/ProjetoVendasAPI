using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infra.Context;


namespace Vendas.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbSet<UsuarioModel> _dbSet;
        private readonly VendasDbContext _context;
        public UsuarioRepository(VendasDbContext context) 
        { 
            _context = context;
            _dbSet = context.Set<UsuarioModel>();
        }
        public async Task<List<UsuarioModel>> BuscarUsuarios()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<bool> CadastrarUsuario(UsuarioModel novoUsuario)
        {
            await _dbSet.AddAsync(novoUsuario);
            
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<UsuarioModel> BuscarUsuario(string login) 
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Login == login);

        }
    }
}
