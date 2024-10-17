using Vendas.Domain.Entities;
using Vendas.Domain.DTOs;

namespace Vendas.Application.Interfaces
{
    public interface IEstoque_ProdutoService
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