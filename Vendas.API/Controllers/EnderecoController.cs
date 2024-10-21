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
                return NoContent();
            return Ok(endereco);
        }

        [HttpGet("endereco-por-cidade/{cidade}")]
        public IActionResult BuscarEnderecoPorCidade(string cidade)
        {
            var response = _enderecoService.BuscarEnderecoPorCidade(cidade);
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-endereco")]
        public IActionResult AdicionarEndereco([FromBody] EnderecoDTO endereco)
        {
            if (_enderecoService.AdicionarEndereco(endereco))
                return Ok("Endereço Adicionado");
            return BadRequest("Erro ao adicionar endereço");
            
        }

        [HttpPut]
        [Route("atualizar-endereco")]
        public IActionResult AtualizarEndereco([FromBody] EnderecoModel endereco)
        {
            var response = _enderecoService.AtualizarEndereco(endereco);
            if (string.IsNullOrEmpty(response))
                return Ok("Endereço Atualizado com sucesso");
            return BadRequest("Erro ao atualizar endereço");
            
        }

        [HttpDelete]
        [Route("remover-endereco")]
        public IActionResult RemoverEndereco(int id)
        {
            var response = _enderecoService.RemoverEndereco(id);
            if (response == false)
                return BadRequest("Erro ao remover endereço");
            return Ok("Endereço Removido com sucesso");
        }
    }
}