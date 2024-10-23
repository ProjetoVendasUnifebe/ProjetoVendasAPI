using Vendas.Application.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Domain.DTOs;
using AutoMapper;

namespace Vendas.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
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

        public bool AdicionarEndereco(EnderecoDTO endereco)
        {
            var novoEndereco = _mapper.Map<EnderecoModel>(endereco);
            return _enderecoRepository.AdicionarEndereco(novoEndereco);
        }

        public string AtualizarEndereco(EnderecoModel endereco)
        {
            return _enderecoRepository.AtualizarEndereco(endereco);
        }

        public bool RemoverEndereco(int id)
        {
            return _enderecoRepository.RemoverEndereco(id);
        }
    }
}