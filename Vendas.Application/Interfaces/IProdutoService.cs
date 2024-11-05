using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IProdutoService
    {
        List<ProdutoModel> BuscarProdutos();
        ProdutoModel BuscarProdutoPorId(int id);
        List<ProdutoModel> BuscarProdutoPorNome(string nome);
        bool AdicionarProduto(ProdutoDTO produto);
        string AtualizarProduto(ProdutoModel produto);
        bool RemoverProduto(int id);
        IEnumerable<ProdutoMaisVendidoDTO> ProdutoMaisVendido();
        IEnumerable<ProdutosDisponiveisPorEstoqueDTO> BuscarProdutosDisponiveisPorEstoque();
    }
}