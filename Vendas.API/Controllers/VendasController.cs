using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Interfaces;
using Vendas.Application.Services;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IProdutoService _produtoService;

        public VendasController(IUsuarioService usuarioService, IProdutoService produtoService)
        {
            _usuarioService = usuarioService;
            _produtoService = produtoService;
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

        [HttpGet]
        [Route("buscar-produtos")]
        public async Task<IActionResult> BuscarProdutos()
        {
            var response = await _produtoService.BuscarProdutos();
            if (response.Count == 0)
                return BadRequest(new ErroDTO("Lista Vazia", "Aparentemente a lista de produtos esta vazia"));
            return Ok(response);
        }

        [HttpGet]
        [Route("buscar-produto-por-id")]
        public IActionResult BuscarProdutoPorId(int id)
        {
            var response = _produtoService.BuscarProdutoPorId(id);
            if (response == null)
                return BadRequest(new ErroDTO("Produto não encontrado", "O produto não foi encontrado"));
            return Ok(response);
        }

        [HttpGet]
        [Route("buscar-produto-por-nome")]
        public IActionResult BuscarProdutoPorNome(string nome)
        {
            var response = _produtoService.BuscarProdutoPorNome(nome);
            if (response == null)
                return BadRequest(new ErroDTO("Produto não encontrado", "O produto não foi encontrado"));
            return Ok(response);
        }

        [HttpPost]
        [Route("adicionar-produto")]
        public IActionResult AdicionarProduto(ProdutoModel produto)
        {
            _produtoService.AdicionarProduto(produto);
            return Ok("Produto Adicionado");
        }

        [HttpPut]
        [Route("atualizar-produto")]
        public IActionResult AtualizarProduto(ProdutoModel produto)
        {
            _produtoService.AtualizarProduto(produto);
            return Ok("Produto Atualizado");
        }

        [HttpDelete]
        [Route("remover-produto")]
        public IActionResult RemoverProduto(int id)
        {
            _produtoService.RemoverProduto(id);
            return Ok("Produto Removido");
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
