using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infra.Context;

namespace Vendas.Infra.Repositories
{
    public class ItensVendidosRepository : IItensVendidosRepository
    {
        private readonly DbSet<ItensVendidosModel> _dbSet;
        private readonly VendasDbContext _context;

        public ItensVendidosRepository(VendasDbContext context)
        {
            _context = context;
            _dbSet = context.Set<ItensVendidosModel>();
        }

        public List<ItensVendidosModel> BuscarTodosItensVendidos()
        {
            return _dbSet.ToList();
        }

        public ItensVendidosModel BuscarItensVendidosPorId(int id)
        {
            return _dbSet.FirstOrDefault(x => x.IdItensVendidos == id);
        }

        public bool CadastrarItensVendidos(ItensVendidosModel novoItensVendidos)
        {
            _dbSet.Add(novoItensVendidos);
            return _context.SaveChanges() > 0;
        }

        public string AtualizarItensVendidos(int id, ItensVendidosModel novoItensVendidos)
        {
            var itensVendidos = BuscarItensVendidosPorId(id);
            if (itensVendidos == null)
                return "ItensVendidos não encontrado";

            itensVendidos.IdVenda = novoItensVendidos.IdVenda > 0 ? novoItensVendidos.IdVenda : itensVendidos.IdVenda;
            itensVendidos.IdProduto = novoItensVendidos.IdProduto > 0 ? novoItensVendidos.IdProduto : itensVendidos.IdProduto;
            itensVendidos.QtdVendida = novoItensVendidos.QtdVendida > 0 ? novoItensVendidos.QtdVendida : itensVendidos.IdVenda;

            _dbSet.Update(itensVendidos);
            if (_context.SaveChanges() > 0)
                return string.Empty;

            return "Erro interno do servidor";
        }

        public bool RemoverItensVendidos(int id)
        {
            var itensVendidos = BuscarItensVendidosPorId(id);
            if (itensVendidos == null)
                return false;

            _dbSet.Remove(itensVendidos);
            return _context.SaveChanges() > 0;
        }


    }
}
