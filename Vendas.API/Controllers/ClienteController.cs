using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("buscar-todos-clientes")]
        public IActionResult ListarClientes()
        {
            var response = _clienteService.BuscarClientes();
            if (response.Count() == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpGet("buscar-cliente-por-id/{id}")]
        public IActionResult BuscarClientePorId(int id)
        {
            var cliente = _clienteService.BuscarClientePorId(id);
            if (cliente == null)
                return NoContent();
            return Ok(cliente);
        }

        [HttpGet("buscar-cliente-por-nome/{nomeCliente}")]
        public IActionResult BuscarClientePorNome(string nomeCliente)
        {
            var response = _clienteService.BuscarClientePorNome(nomeCliente);
            if (response.Count() == 0)
                return NoContent();
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-cliente")]
        public IActionResult AdicionarCliente([FromBody] ClienteInputDTO cliente)
        {
            var response = _clienteService.AdicionarCliente(cliente);
            if (!response)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut]
        [Route("atualizar-cliente")]
        public IActionResult AtualizarCliente([FromBody] ClienteModel cliente)
        {
            var response = _clienteService.AtualizarCliente(cliente);
            if (string.IsNullOrEmpty(response))
                return Ok("Cliente Atualizado Com Sucesso");
            return BadRequest(response);
        }

        [HttpDelete("remover-cliente/{id}")]
        public IActionResult RemoverCliente(int id)
        {
            var response = _clienteService.RemoverCliente(id);
            if (!response)
                return BadRequest(response); 
            return Ok(response);
        }
    }
}