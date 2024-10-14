using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
       private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        [Route("listar-enderecos")]
        public IActionResult ListarEnderecos()
        {
            var response = _enderecoService.ListarEnderecos();
            if (response.Count == 0)
                return BadRequest(new ErroDTO("Lista Vazia", "Aparentemente a lista de endereços esta vazia"));
            return Ok(response);
        }

        [HttpGet("endereco-por-id/{id}")]
        public IActionResult BuscarEnderecoPorId(int id)
        {
            var endereco = _enderecoService.BuscarEnderecoPorId(id);
            if (endereco == null)
                return BadRequest(new ErroDTO("Endereço não encontrado", "O endereço não foi encontrado"));
            return Ok(endereco);
        }

        [HttpGet("endereco-por-cidade/{cidade}")]
        public IActionResult BuscarEnderecoPorCidade(string cidade)
        {
            var response = _enderecoService.BuscarEnderecoPorCidade(cidade);
            if (response.Count == 0)
                return BadRequest(new ErroDTO("Endereço não encontrado", "O endereço não foi encontrado"));
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-endereco")]
        public IActionResult AdicionarEndereco(EnderecoModel endereco)
        {
            _enderecoService.AdicionarEndereco(endereco);
            return Ok("Endereço Adicionado");
        }

        [HttpPut]
        [Route("atualizar-endereco")]
        public IActionResult AtualizarEndereco(EnderecoModel endereco)
        {
            _enderecoService.AtualizarEndereco(endereco);
            return Ok("Endereço Atualizado");
        }

        [HttpDelete]
        [Route("remover-endereco")]
        public IActionResult RemoverEndereco(int id)
        {
            _enderecoService.RemoverEndereco(id);
            return Ok("Endereço Removido");
        }
    }
}