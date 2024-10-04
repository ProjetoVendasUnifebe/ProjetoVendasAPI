using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
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
        public IActionResult BuscarUsuarios()
        {
            var response = _usuarioService.BuscarUsuarios();
            if (response.Count == 0)
                return BadRequest(new ErroDTO("Lista Vazia", "Aparentemente a lista esta vazia"));
            return Ok(response);
        }

        [HttpPost]
        [Route("cadastrar-usuario")]

        public bool CadastrarUsuario([FromBody] CadastroUsuarioInputDTO  novoUsuario)
        {

            if (!_usuarioService.CadastrarUsuario(novoUsuario))
                return false;

            return true;
        }

    }
}
