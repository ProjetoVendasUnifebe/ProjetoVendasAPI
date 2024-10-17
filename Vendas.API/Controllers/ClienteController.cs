using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("listar-clientes")]
        public IActionResult ListarClientes()
        {
            var response = _clienteService.BuscarClientes();
            if (response.Count() == 0)
                return BadRequest(new ErroDTO("Lista Vazia", "Aparentemente a lista de clientes esta vazia"));
            return Ok(response);
        }

        [HttpGet("cliente-por-id/{id}")]
        public IActionResult BuscarClientePorId(int id)
        {
            var cliente = _clienteService.BuscarClientePorId(id);
            if (cliente == null)
                return BadRequest(new ErroDTO("Cliente não encontrado", "O cliente não foi encontrado"));
            return Ok(cliente);
        }

        [HttpGet("cliente-por-nome/{nomeCliente}")]
        public IActionResult BuscarClientePorNome(string nomeCliente)
        {
            var response = _clienteService.BuscarClientePorNome(nomeCliente);
            if (response.Count() == 0)
                return BadRequest(new ErroDTO("Cliente não encontrado", "O cliente não foi encontrado"));
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-cliente")]
        public IActionResult AdicionarCliente([FromBody] ClienteModel cliente)
        {
            var response = _clienteService.AdicionarCliente(cliente);
            if (response == false)
                return BadRequest(new ErroDTO("Erro ao adicionar cliente", "Ocorreu um erro ao adicionar o cliente"));
            return Ok("Cliente Adicionado");
        }

        [HttpPut]
        [Route("atualizar-cliente")]
        public IActionResult AtualizarCliente([FromBody] ClienteModel cliente)
        {
            var response = _clienteService.AtualizarCliente(cliente);
            if (response == false)
                return BadRequest(new ErroDTO("Erro ao atualizar cliente", "Ocorreu um erro ao atualizar o cliente"));
            return Ok("Cliente Atualizado");
        }

        [HttpDelete("remover-cliente/{id}")]
        public IActionResult RemoverCliente(int id)
        {
            var response = _clienteService.RemoverCliente(id);
            if (response == false)
                return BadRequest(new ErroDTO("Erro ao remover cliente", "Ocorreu um erro ao remover o cliente")); 
            return Ok("Cliente Removido");
        }
    }
}