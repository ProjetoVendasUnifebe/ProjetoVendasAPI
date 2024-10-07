using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        List<ProdutoModel> BuscarProdutos();
        ProdutoModel BuscarProdutoPorId(int id);
        ProdutoModel BuscarProdutoPorNome(string nome);
        void AdicionarProduto(ProdutoModel produto);
        void AtualizarProduto(ProdutoModel produto);
    }
}