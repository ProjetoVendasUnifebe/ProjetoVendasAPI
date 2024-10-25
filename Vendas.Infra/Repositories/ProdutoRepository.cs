using Microsoft.EntityFrameworkCore;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces.Dapper;
using Vendas.Domain.Interfaces.Repositories;
using Vendas.Infra.Context;

namespace Vendas.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DbSet<ProdutoModel> _dbSet;
        private readonly VendasDbContext _context;
        private readonly IDapperVendas _dapperVendas;

        public ProdutoRepository(VendasDbContext context, IDapperVendas dapperVendas)
        {
            _dapperVendas = dapperVendas;
            _context = context;
            _dbSet = context.Set<ProdutoModel>();
        }

        public List<ProdutoModel> BuscarProdutos()
        {
            return _dbSet.ToList();
        }

        public ProdutoModel BuscarProdutoPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public List<ProdutoModel> BuscarProdutoPorNome(string nome)
        {
            return _dbSet.Where(x => EF.Functions.Like(x.NomeProduto.ToLower(), $"%{nome.ToLower()}%")).ToList();
        }

        public bool AdicionarProduto(ProdutoModel novoProduto)
        {
            _dbSet.Add(novoProduto);
            return _context.SaveChanges() > 0;

        }

        public string AtualizarProduto(ProdutoModel produtoAtualizado)
        {
            var produto = BuscarProdutoPorId(produtoAtualizado.IdProduto);
            if (produto == null)
                return "Produto não encontrado";
            produto.NomeProduto = string.IsNullOrEmpty(produtoAtualizado.NomeProduto) ? produto.NomeProduto : produtoAtualizado.NomeProduto;
            produto.Valor = produtoAtualizado.Valor != 0 ? produtoAtualizado.Valor : produto.Valor;
            produto.Descricao = string.IsNullOrEmpty(produtoAtualizado.Descricao) ? produto.Descricao : produtoAtualizado.Descricao;

            _dbSet.Update(produto);
            if(_context.SaveChanges() > 0)
                return string.Empty;
            
            return "Falha ao atualizar o produto";
        }

        public bool RemoverProduto(int id)
        {
            var produto = _dbSet.Find(id);

            if (produto == null) 
                return false;

            _dbSet.Remove(produto);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<ProdutoMaisVendidoDTO> ListarProdutosMaisVendidos()
        {
            var query = $@"SELECT 
                p.""idProduto"" AS IdProduto,
                p.nome AS NomeProduto,
                SUM(iv.""qtdVendida"") AS TotalVendido
                    FROM comercialize.""itensVendidos"" iv
                JOIN 
                    comercialize.produto p ON iv.""idProduto"" = p.""idProduto""
                GROUP BY 
                    p.""idProduto"", p.nome
                ORDER BY 
                    TotalVendido DESC
                LIMIT 5;";

            return _dapperVendas.RunQueryVendas<ProdutoMaisVendidoDTO>(query);
        }

        public IEnumerable<ProdutosDisponiveisPorEstoqueDTO> BuscarProdutosDisponiveisPorEstoque()
        {
            var query = $@"SELECT 
                sp.""idEstoque_Produto"" AS IdEstoque_Produto,
                p.nome AS NomeProduto,
                s.nome AS Estoque,
                sp.quantidade AS Quantidade
                    FROM comercialize.estoque_produto sp
                JOIN 
                    comercialize.produto p ON sp.""idProduto"" = p.""idProduto""
                JOIN 
                    comercialize.estoque s ON sp.""idEstoque"" = s.""idEstoque"";";

            return _dapperVendas.RunQueryVendas<ProdutosDisponiveisPorEstoqueDTO>(query);
        }

    }
}

