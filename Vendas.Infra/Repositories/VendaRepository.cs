using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Tracing;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces.Repositories;
using Vendas.Infra.Context;

namespace Vendas.Infra.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DbSet<VendaModel> _dbSet;
        private readonly VendasDbContext _context;
        public VendaRepository(VendasDbContext context) 
        {
            _context = context;
            _dbSet = context.Set<VendaModel>();
        }
        public List<VendaModel> BuscarVendas()
        {
            return _dbSet.ToList();
        }

        public List<VendaModel> BuscarVendasPorData(DateTime? dataInicio, DateTime? dataFim)
        {
            var query = _dbSet.AsQueryable();

            if (dataInicio.HasValue)
            {
                query = query.Where(v => v.data_venda >= dataInicio.Value.ToUniversalTime());
            }

            if (dataFim.HasValue)
            {

                query = query.Where(v => v.data_venda <= dataFim.Value.ToUniversalTime());
            }

            return query.ToList();
        }

        public bool CadastrarVenda(VendaModel novaVenda)
        {
            novaVenda.data_venda = DateTime.UtcNow.AddHours(-3);
            _dbSet.Add(novaVenda);
            return _context.SaveChanges() > 0;
        }

        public string AtualizarVenda(VendaModel novaVenda) 
        {
                var venda = BuscarVendaPorId(novaVenda.IdVenda);
                if (venda == null)
                    return "Venda não encontrada";

                venda.IdCliente = novaVenda.IdCliente > 0 ? novaVenda.IdCliente : venda.IdCliente;
                venda.IdUsuario = novaVenda.IdUsuario > 0 ? novaVenda.IdUsuario : venda.IdUsuario;
                venda.valor = novaVenda.valor > 0 ? novaVenda.valor : venda.valor;
                venda.forma_pagamento = string.IsNullOrEmpty(novaVenda.forma_pagamento) ? venda.forma_pagamento : novaVenda.forma_pagamento;
                venda.data_venda = novaVenda.data_venda == default(DateTime) ? venda.data_venda.ToUniversalTime().AddHours(-3) : novaVenda.data_venda.Kind == DateTimeKind.Utc ? novaVenda.data_venda : novaVenda.data_venda.ToUniversalTime().AddHours(-3);

                _dbSet.Update(venda);
                if (_context.SaveChanges() > 0)
                    return string.Empty;

                return "Erro interno do servidor";
        }

        public bool RemoverVenda(int id)
        {
            var venda = _dbSet.Find(id);
            if (venda == null)
                return false;

            _dbSet.Remove(venda);
            return _context.SaveChanges() > 0;
        }

        public VendaModel BuscarVendaPorId(int id)
        {
            return _dbSet.FirstOrDefault(x => x.IdVenda == id);
        }

    }
}
