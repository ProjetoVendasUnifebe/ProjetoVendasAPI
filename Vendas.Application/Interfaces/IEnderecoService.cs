using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IEnderecoService
    {
        List<EnderecoModel> ListarEnderecos();
        EnderecoModel BuscarEnderecoPorId(int id);
        List<EnderecoModel> BuscarEnderecoPorCidade(string cidade);
        bool AdicionarEndereco(EnderecoDTO endereco);
        string AtualizarEndereco(EnderecoModel endereco);
        bool RemoverEndereco(int id);

    }
}