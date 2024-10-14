using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController( IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet]
        [Route("buscar-estoques")]
        public IActionResult BuscarEstoques()
        {
            var response = _estoqueService.BuscarEstoques();
            if (response.Count == 0)
                return BadRequest(new ErroDTO("Lista Vazia", "Aparentemente a lista de estoques esta vazia"));
            return Ok(response);
        }

        [HttpGet("estoque-por-id/{id}")]
        public IActionResult BuscarEstoquePorId(int id)
        {
            var estoque = _estoqueService.BuscarEstoquePorId(id);
            if (estoque == null)
                return BadRequest(new ErroDTO("Estoque não encontrado", "O estoque não foi encontrado"));
            return Ok(estoque);
        }

        [HttpGet("estoque-por-nome/{nomeEstoque}")]
        public IActionResult BuscarEstoquePorNome(string nomeEstoque)
        {
            var response = _estoqueService.BuscarEstoquePorNome(nomeEstoque);
            if (response == null)
                return BadRequest(new ErroDTO("Estoque não encontrado", "O estoque não foi encontrado"));
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-estoque")]
        public IActionResult AdicionarEstoque(EstoqueModel estoque)
        {
            _estoqueService.AdicionarEstoque(estoque);
            return Ok("Estoque Adicionado");
        }

        [HttpPut]
        [Route("atualizar-estoque")]
        public IActionResult AtualizarEstoque(EstoqueModel estoque)
        {
            _estoqueService.AtualizarEstoque(estoque);
            return Ok("Estoque Atualizado");
        }

        [HttpDelete]
        [Route("remover-estoque")]
        public IActionResult RemoverEstoque(int id)
        {
            _estoqueService.RemoverEstoque(id);
            return Ok("Estoque Removido");
        }
    }
}
