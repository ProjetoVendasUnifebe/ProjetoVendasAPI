using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IProdutoService
    {
        List<ProdutoModel> BuscarProdutos();
        ProdutoModel BuscarProdutoPorId(int id);
        List<ProdutoModel> BuscarProdutoPorNome(string nome);
        bool AdicionarProduto(ProdutoModel produto);
        bool AtualizarProduto(ProdutoModel produto);
        bool RemoverProduto(int id);
    }
}