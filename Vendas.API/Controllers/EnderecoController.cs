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
        [Route("buscar-todos-enderecos")]
        public IActionResult ListarEnderecos()
        {
            var response = _enderecoService.ListarEnderecos();
            if (response.Count == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet("buscar-endereco-por-id/{id}")]
        public IActionResult BuscarEnderecoPorId(int id)
        {
            var endereco = _enderecoService.BuscarEnderecoPorId(id);
            if (endereco == null)
                return NoContent();
            return Ok(endereco);
        }

        [HttpGet("buscar-endereco-por-cidade/{cidade}")]
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
            var response = _enderecoService.AdicionarEndereco(endereco);
            if (response != 0)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut]
        [Route("atualizar-endereco")]
        public IActionResult AtualizarEndereco([FromBody] EnderecoModel endereco)
        {
            var response = _enderecoService.AtualizarEndereco(endereco);
            if (string.IsNullOrEmpty(response))
                return Ok("Endereço Atualizado com sucesso");
            return BadRequest(response);
            
        }

        [HttpDelete]
        [Route("remover-endereco/{id}")]
        public IActionResult RemoverEndereco(int id)
        {
            var response = _enderecoService.RemoverEndereco(id);
            if (response == false)
                return BadRequest(response);
            return Ok(response);
        }
    }
}