using Vendas.Domain.Entities;
using Vendas.Domain.DTOs;

namespace Vendas.Application.Interfaces
{
    public interface IEstoque_ProdutoService
    {
        List<EstoqueProdutoModel> BuscarEstoqueProduto();
        EstoqueProdutoModel BuscarEstoqueProdutoPorId(int id);
        List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdProduto(int idProduto);
        List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdEstoque(int idEstoque);
        List<EstoqueProdutoModel> BuscarEstoqueProdutoPorQuantidade(int quantidade);
        bool AdicionarEstoqueProduto(EstoqueProdutoDTO estoqueProduto);
        string AtualizarEstoqueProduto(EstoqueProdutoModel estoqueProduto);
        bool RemoverEstoqueProduto(int idEstoqueProduto);
    }
}