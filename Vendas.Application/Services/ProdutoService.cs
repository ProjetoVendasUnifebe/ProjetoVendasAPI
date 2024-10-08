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

    public Task<List<ProdutoModel>> BuscarProdutos()
    {
        var response = _produtoRepository.BuscarProdutos();
        if (response == null)
            return Task.FromResult(new List<ProdutoModel>());

        return response;
    }
    public async Task<ProdutoModel> BuscarProdutoPorId(int id)
    {
        var produto = await _produtoRepository.BuscarProdutoPorId(id);
        return produto; 
    }

    public async Task<List<ProdutoModel>> BuscarProdutoPorNome(string nome)
    {
        var produto = await _produtoRepository.BuscarProdutoPorNome(nome);
        return produto; 
    }

    public async Task AdicionarProduto(ProdutoModel produto)
    {
        await _produtoRepository.AdicionarProduto(produto);
    }

    public async Task AtualizarProduto(ProdutoModel produto)
    {
        await _produtoRepository.AtualizarProduto(produto);
    }

    public async Task RemoverProduto(int id)
    {
        _produtoRepository.RemoverProduto(id);
    }
    }
}