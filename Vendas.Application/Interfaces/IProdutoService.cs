using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IProdutoService
    {
        List<ProdutoModel> BuscarProdutos();
        ProdutoModel BuscarProdutoPorId(int id);
        ProdutoModel BuscarProdutoPorNome(string nome);
        void AdicionarProduto(ProdutoModel produto);
        void AtualizarProduto(ProdutoModel produto);
        void RemoverProduto(int id);
    }
}
