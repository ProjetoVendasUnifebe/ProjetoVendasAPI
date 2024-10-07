using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vendas.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<List<ProdutoModel>> BuscarProdutos();
        Task<ProdutoModel> BuscarProdutoPorId(int id);
        Task<ProdutoModel> BuscarProdutoPorNome(string nome);
        Task AdicionarProduto(ProdutoModel produto);
        Task AtualizarProduto(ProdutoModel produto);
        Task RemoverProduto(int id);
    }
}