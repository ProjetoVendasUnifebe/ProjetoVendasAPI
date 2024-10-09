using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<ProdutoModel>> BuscarProdutos();
        Task<ProdutoModel> BuscarProdutoPorId(int id);
        Task<List<ProdutoModel>> BuscarProdutoPorNome(string nome);
        Task AdicionarProduto(ProdutoModel produto);
        Task<bool> AtualizarProduto(ProdutoModel produto);
        bool RemoverProduto(int id);
    }
}