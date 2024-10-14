using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        List<EnderecoModel> ListarEnderecos();
        EnderecoModel BuscarEnderecoPorId(int id);
        List<EnderecoModel> BuscarEnderecoPorCidade(string cidade);
        bool AdicionarEndereco(EnderecoModel endereco);
        bool AtualizarEndereco(EnderecoModel endereco);
        bool RemoverEndereco(int id);

    }
}