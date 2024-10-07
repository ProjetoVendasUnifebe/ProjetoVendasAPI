using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Application.Services;
using Vendas.Domain.DTOs;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;

        public VendasController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("buscar-usuarios")]
        public async Task<IActionResult> BuscarUsuarios()
        {
            var response = await _usuarioService.BuscarUsuarios();
            if (response.Count == 0)
                return BadRequest(new ErroDTO("Lista Vazia", "Aparentemente a lista esta vazia"));
            return Ok(response);
        }

        [HttpPost]
        [Route("cadastrar-usuario")]

        public async Task< bool> CadastrarUsuario([FromBody] CadastroUsuarioInputDTO novoUsuario)
        {

            if ( !await _usuarioService.CadastrarUsuario(novoUsuario))
                return false;

            return true;
        }

        [HttpGet]
        [Route("buscar-usuario")]

        public async Task<IActionResult> BuscarUsuario([FromQuery] string login)
        {
            if (string.IsNullOrEmpty(login))
                return BadRequest(new ErroDTO("Parametro Vazio", "O parametro não pode estar vazio"));

            var response = await _usuarioService.BuscarUsuario(login);

            if(response != null)
                return Ok(response);
            return BadRequest();
        }
    }
}
