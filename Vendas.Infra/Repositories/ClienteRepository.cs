using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces.Repositories;
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
            return _dbSet.Where(x => EF.Functions.Like(x.Nome.ToLower(), $"%{nomeCliente.ToLower()}%")).ToList();
        }

        public bool AdicionarCliente(ClienteModel cliente)
        {
            _dbSet.Add(cliente);
            return _context.SaveChanges() > 0;
        }

        public string AtualizarCliente(ClienteModel novoCliente)
        {
            var cliente = BuscarClientePorId(novoCliente.IdCliente);
            if (cliente == null)
                return "Cliente não encontrado";

            cliente.Nome = string.IsNullOrEmpty(novoCliente.Nome) ? cliente.Nome : novoCliente.Nome;
            cliente.Cpf = string.IsNullOrEmpty(novoCliente.Cpf) ? cliente.Cpf : novoCliente.Cpf;
            cliente.Email = string.IsNullOrEmpty(novoCliente.Email) ? cliente.Email : novoCliente.Email;
            cliente.Telefone = string.IsNullOrEmpty(novoCliente.Telefone) ? cliente.Telefone : novoCliente.Telefone;
            cliente.Sexo = string.IsNullOrEmpty(novoCliente.Sexo) ? cliente.Sexo : novoCliente.Sexo;
            cliente.IdEndereco = novoCliente.IdEndereco == 0 ? cliente.IdEndereco : novoCliente.IdEndereco;

        _dbSet.Update(cliente);
            if (_context.SaveChanges() > 0)
                return string.Empty;

            return "Erro interno do servidor";
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