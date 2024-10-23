using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IEstoque_ProdutoRepository
    {
        List<EstoqueProdutoModel> BuscarEstoqueProduto();
        EstoqueProdutoModel BuscarEstoqueProdutoPorId(int idEstoqueProduto);
        List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdProduto(int idProduto);
        List<EstoqueProdutoModel> BuscarEstoqueProdutoPorIdEstoque(int idEstoque);
        bool AdicionarEstoqueProduto(EstoqueProdutoModel estoqueProduto);
        string AtualizarEstoqueProduto(EstoqueProdutoModel estoqueProduto);
        bool RemoverEstoqueProduto(int idEstoqueProduto);
        
    }
}