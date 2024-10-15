using Vendas.Application.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services
{
   public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    public List<ProdutoModel> BuscarProdutos()
    {
        var response = _produtoRepository.BuscarProdutos();
        if (response == null)
            return new List<ProdutoModel>();

        return response;
    }

    public ProdutoModel BuscarProdutoPorId(int id)
    {
        var produto = _produtoRepository.BuscarProdutoPorId(id);
        return produto;
    }

    public List<ProdutoModel> BuscarProdutoPorNome(string nome)
    {
        var produto = _produtoRepository.BuscarProdutoPorNome(nome);
        return produto;
    }

    public bool AdicionarProduto(ProdutoModel produto)
    {
        return _produtoRepository.AdicionarProduto(produto);
    }

    public bool AtualizarProduto(ProdutoModel produto)
    {
        return _produtoRepository.AtualizarProduto(produto);
    }

    public bool RemoverProduto(int id)
    {
        return _produtoRepository.RemoverProduto(id);
    }
    }
}