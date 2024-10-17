using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IEstoque_ProdutoService
    {
        List<EstoqueProdutoModel> BuscarEstoqueProduto();
        List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdProduto(int idProduto);
        List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdEstoque(int idEstoque);
        List<EstoqueProdutoModel> BuscarEstoqueProdutoPorQuantidade(int quantidade);
        bool AdicionarEstoqueProduto(EstoqueProdutoModel estoqueProduto);
        bool AtualizarEstoqueProduto(EstoqueProdutoModel estoqueProduto);
        bool RemoverEstoqueProduto(int idEstoqueProduto);
    }
}