using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Infra.Context;

namespace Vendas.Infra.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DbSet<EnderecoModel> _dbSet;
        private readonly VendasDbContext _context;

        public EnderecoRepository(VendasDbContext context)
        {
            _context = context;
            _dbSet = context.Set<EnderecoModel>();
        }

        public List<EnderecoModel> ListarEnderecos()
        {
            return _dbSet.ToList();
        }

        public EnderecoModel BuscarEnderecoPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public List<EnderecoModel> BuscarEnderecoPorCidade(string nomeCidade)
        {
            return _dbSet
                .Where(x => x.Cidade.Contains(nomeCidade))
                .ToList();
        }

        public bool AdicionarEndereco(EnderecoModel endereco)
        {
            _dbSet.Add(endereco);
            return _context.SaveChanges() > 0;
        }

        public bool AtualizarEndereco(EnderecoModel endereco)
        {
            _dbSet.Update(endereco);
            return _context.SaveChanges() > 0;
        }

        public bool RemoverEndereco(int id)
        {
            var endereco = _dbSet.Find(id);
            
            if(endereco == null)
                return false;
            
            _dbSet.Remove(endereco);
            _context.SaveChanges();
            return true;
        }
    }
}