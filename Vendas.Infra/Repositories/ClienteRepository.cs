using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infra.Context;

namespace Vendas.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbSet<ClienteModel> _dbSet;
        private readonly VendasDbContext _context;
        public ClienteRepository(VendasDbContext context) 
        { 
            _context = context;
            _dbSet = context.Set<ClienteModel>();
        }
        public List<ClienteModel> BuscarClientes()
        {
            return _dbSet.ToList();
        }

        public ClienteModel BuscarClientePorId(int id)
        {
            return _dbSet.Find(id);
        }

        public List<ClienteModel> BuscarClientePorNome(string nomeCliente)
        {
            return _dbSet.Where(x => x.Nome.Contains(nomeCliente)).ToList();
        }

        public bool AdicionarCliente(ClienteModel cliente)
        {
            _dbSet.Add(cliente);
            return _context.SaveChanges() > 0;
        }

        public bool AtualizarCliente(ClienteModel cliente)
        {
            _dbSet.Update(cliente);
            return _context.SaveChanges() > 0;
        }

        public bool RemoverCliente(int id)
        {
            var cliente = _dbSet.Find(id);
            if (cliente == null)
                return false;
            _dbSet.Remove(cliente);
            _context.SaveChanges();
            return true;
        }
    }
}