using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        List<ProdutoModel> BuscarProdutos();
    }
}