using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.DTOs;

namespace Vendas.API.Controllers
{
    public class Estoque_ProdutoController : ControllerBase
    {
        private readonly IEstoque_ProdutoService _estoqueProdutoService;
        public Estoque_ProdutoController(IEstoque_ProdutoService estoque_produtoService)
        {
            _estoqueProdutoService = estoque_produtoService;
        }

        [HttpGet]
        [Route("listar-estoque-produto")]
        public IActionResult ListarEstoqueProduto()
        {
            var response = _estoqueProdutoService.BuscarEstoqueProduto();
            if (response.Count == 0)
                return BadRequest("Lista Vazia");
            return Ok(response);
        }

        [HttpGet("estoque-produto-por-id/{id}")]
        public IActionResult BuscarEstoqueProdutoPorId(int id)
        {
            var response = _estoqueProdutoService.BuscarEstoqueProdutoPorId(id);
            if (response == null)
                return NoContent();
            return Ok(response);
        }

        [HttpGet("estoque-produto-por-id-produto/{idProduto}")]
        public IActionResult BuscarEstoqueProdutoPorIdProduto(int idProduto)
        {
            var response = _estoqueProdutoService.BuscarEstoqueProdutoPorIdProduto(idProduto);
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet("estoque-produto-por-id-estoque/{idEstoque}")]
        public IActionResult BuscarEstoqueProdutoPorIdEstoque(int idEstoque)
        {
            var response = _estoqueProdutoService.BuscarEstoqueProdutoPorIdEstoque(idEstoque);
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet("estoque-produto-por-quantidade/{quantidade}")]
        public IActionResult BuscarEstoqueProdutoPorQuantidade(int quantidade)
        {
            var response = _estoqueProdutoService.BuscarEstoqueProdutoPorQuantidade(quantidade);
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-estoque-produto")]
        public IActionResult AdicionarEstoqueProduto([FromBody] EstoqueProdutoDTO estoqueProduto)
        { 
            if (_estoqueProdutoService.AdicionarEstoqueProduto(estoqueProduto))
                return Ok("Estoque Produto Adicionado");
            return BadRequest("Erro ao adicionar Estoque Produto");
        }

        [HttpPut]
        [Route("atualizar-estoque-produto")]
        public IActionResult AtualizarEstoqueProduto([FromBody] EstoqueProdutoModel estoqueProduto)
        {
            var response = _estoqueProdutoService.AtualizarEstoqueProduto(estoqueProduto);
            if (string.IsNullOrEmpty(response))
                return Ok("Estoque Produto Atualizado");
            return BadRequest("Erro ao atualizar Estoque Produto");
            
        }

        [HttpDelete("remover-estoque-produto/{idEstoqueProduto}")]
        public IActionResult RemoverEstoqueProduto(int idEstoqueProduto)
        {
            var response = _estoqueProdutoService.RemoverEstoqueProduto(idEstoqueProduto);
            if (response == false)
                return BadRequest("Erro ao remover Estoque Produto");
            return Ok("Estoque Produto Removido");
        }
        
    }
}