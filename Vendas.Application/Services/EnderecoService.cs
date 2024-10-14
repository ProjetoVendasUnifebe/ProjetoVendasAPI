using Vendas.Application.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;

namespace Vendas.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public List<EnderecoModel> ListarEnderecos()
        {
            return _enderecoRepository.ListarEnderecos();
        }

        public EnderecoModel BuscarEnderecoPorId(int id)
        {
            return _enderecoRepository.BuscarEnderecoPorId(id);
        }

        public List<EnderecoModel> BuscarEnderecoPorCidade(string cidade)
        {
            return _enderecoRepository.BuscarEnderecoPorCidade(cidade);
        }

        public bool AdicionarEndereco(EnderecoModel endereco)
        {
            return _enderecoRepository.AdicionarEndereco(endereco);
        }

        public bool AtualizarEndereco(EnderecoModel endereco)
        {
            return _enderecoRepository.AtualizarEndereco(endereco);
        }

        public bool RemoverEndereco(int id)
        {
            return _enderecoRepository.RemoverEndereco(id);
        }
    }
}