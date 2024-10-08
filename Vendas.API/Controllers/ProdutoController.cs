using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Application.Services;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController( IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [Route("buscar-produtos")]
        public async Task<IActionResult> BuscarProdutos()
        {
            var response = await _produtoService.BuscarProdutos();
            if (response.Count == 0)
                return BadRequest(new ErroDTO("Lista Vazia", "Aparentemente a lista de produtos esta vazia"));
            return Ok(response);
        }

        [HttpGet("produto-por-id/{id}")]
        
        public async Task<IActionResult> BuscarProdutoPorId(int id)
        {
            var produto = await _produtoService.BuscarProdutoPorId(id);
            if (produto == null)
                return BadRequest(new ErroDTO("Produto não encontrado", "O produto não foi encontrado"));
            return Ok(produto);
        }

        [HttpGet("produto-por-nome/{nome}")]
        public async Task<IActionResult> BuscarProdutoPorNome(string nome)
        {
            var response = await _produtoService.BuscarProdutoPorNome(nome);
            if (response == null)
                return BadRequest(new ErroDTO("Produto não encontrado", "O produto não foi encontrado"));
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-produto")]
        public IActionResult AdicionarProduto(ProdutoModel produto)
        {
            _produtoService.AdicionarProduto(produto);
            return Ok("Produto Adicionado");
        }

        [HttpPut]
        [Route("atualizar-produto")]
        public IActionResult AtualizarProduto(ProdutoModel produto)
        {
            _produtoService.AtualizarProduto(produto);
            return Ok("Produto Atualizado");
        }

        [HttpDelete("remover-produto")]
        public IActionResult RemoverProduto(int id)
        {
            try
            {
                _produtoService.RemoverProduto(id);
                return Ok("Produto Removido");
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}
