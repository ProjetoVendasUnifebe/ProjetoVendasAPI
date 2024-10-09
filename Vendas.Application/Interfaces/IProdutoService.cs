using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<List<ProdutoModel>> BuscarProdutos();
        Task<ProdutoModel> BuscarProdutoPorId(int id);
        Task<List<ProdutoModel>> BuscarProdutoPorNome(string nome);
        Task AdicionarProduto(ProdutoModel produto);
        Task AtualizarProduto(ProdutoModel produto);
        bool RemoverProduto(int id);
    }
}