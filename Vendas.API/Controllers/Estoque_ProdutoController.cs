using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.DTOs;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Estoque_ProdutoController : ControllerBase
    {
        private readonly IEstoque_ProdutoService _estoqueProdutoService;
        public Estoque_ProdutoController(IEstoque_ProdutoService estoque_produtoService)
        {
            _estoqueProdutoService = estoque_produtoService;
        }

        [HttpGet]
        [Route("buscar-todos-estoque-produto")]
        public IActionResult ListarEstoqueProduto()
        {
            var response = _estoqueProdutoService.BuscarEstoqueProduto();
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet("buscar-estoque-produto-por-id/{id}")]
        public IActionResult BuscarEstoqueProdutoPorId(int id)
        {
            var response = _estoqueProdutoService.BuscarEstoqueProdutoPorId(id);
            if (response == null)
                return NoContent();
            return Ok(response);
        }

        [HttpGet("buscar-produto-por-id-produto/{idProduto}")]
        public IActionResult BuscarEstoqueProdutoPorIdProduto(int idProduto)
        {
            var response = _estoqueProdutoService.BuscarEstoqueProdutoPorIdProduto(idProduto);
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet("buscar-estoque-por-id-estoque/{idEstoque}")]
        public IActionResult BuscarEstoqueProdutoPorIdEstoque(int idEstoque)
        {
            var response = _estoqueProdutoService.BuscarEstoqueProdutoPorIdEstoque(idEstoque);
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-estoque-produto")]
        public IActionResult AdicionarEstoqueProduto([FromBody] EstoqueProdutoDTO estoqueProduto)
        {
            var response = _estoqueProdutoService.AdicionarEstoqueProduto(estoqueProduto);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut]
        [Route("atualizar-estoque-produto")]
        public IActionResult AtualizarEstoqueProduto([FromBody] EstoqueProdutoAtualizaDTO estoqueProduto)
        {
            var response = _estoqueProdutoService.AtualizarEstoqueProduto(estoqueProduto);

            if (string.IsNullOrEmpty(response))
                return Ok("Estoque Produto Atualizado com sucesso");
            return BadRequest(response);
            
        }

        [HttpDelete("remover-estoque-produto/{idEstoqueProduto}")]
        public IActionResult RemoverEstoqueProduto(int idEstoqueProduto)
        {
            var response = _estoqueProdutoService.RemoverEstoqueProduto(idEstoqueProduto);
            if (!response)
                return BadRequest(response);
            return Ok(response);
        }
        
    }
}