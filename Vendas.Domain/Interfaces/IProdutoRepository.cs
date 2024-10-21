using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        List<ProdutoModel> BuscarProdutos();
        ProdutoModel BuscarProdutoPorId(int id);
        List<ProdutoModel> BuscarProdutoPorNome(string nome);
        bool AdicionarProduto(ProdutoModel produto);
        string AtualizarProduto(ProdutoModel produto);
        bool RemoverProduto(int id);
    }
}