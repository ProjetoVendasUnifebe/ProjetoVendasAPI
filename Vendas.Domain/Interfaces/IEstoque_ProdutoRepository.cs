using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IEstoque_ProdutoRepository
    {
        List<EstoqueProdutoModel> BuscarEstoqueProduto();
        List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdProduto(int idProduto);
        List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdEstoque(int idEstoque);
        List<EstoqueProdutoModel> BuscarEstoqueProdutoPorQuantidade(int quantidade);
        bool AdicionarEstoqueProduto(EstoqueProdutoModel estoqueProduto);
        string AtualizarEstoqueProduto(int id, Estoque_ProdutoDTO estoqueProduto);
        bool RemoverEstoqueProduto(int idEstoqueProduto);
    }
}