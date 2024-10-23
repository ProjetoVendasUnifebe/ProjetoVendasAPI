using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Interfaces;
using Vendas.Domain.Entities;
using Vendas.Infra.Context;

namespace Vendas.Infra.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DbSet<EnderecoModel> _dbSet;
        private readonly VendasDbContext _context;

        public EnderecoRepository(VendasDbContext context)
        {
            _context = context;
            _dbSet = context.Set<EnderecoModel>();
        }

        public List<EnderecoModel> ListarEnderecos()
        {
            return _dbSet.ToList();
        }

        public EnderecoModel BuscarEnderecoPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public List<EnderecoModel> BuscarEnderecoPorCidade(string nomeCidade)
        {
            return _dbSet.Where(x => EF.Functions.Like(x.Cidade.ToLower(), $"%{nomeCidade.ToLower()}%")).ToList();
        }

        public bool AdicionarEndereco(EnderecoModel endereco)
        {
            _dbSet.Add(endereco);
            return _context.SaveChanges() > 0;
        }

        public string AtualizarEndereco(EnderecoModel endereco)
        {
            var enderecoAtual = _dbSet.Find(endereco.IdEndereco);
            if (enderecoAtual == null)
                return "Endereço não encontrado";

            enderecoAtual.Pais = string.IsNullOrEmpty(endereco.Pais) ? enderecoAtual.Pais : endereco.Pais;
            enderecoAtual.Rua = string.IsNullOrEmpty(endereco.Rua) ? enderecoAtual.Rua : endereco.Rua;
            enderecoAtual.Cidade = string.IsNullOrEmpty(endereco.Cidade) ? enderecoAtual.Cidade : endereco.Cidade;
            enderecoAtual.Estado = string.IsNullOrEmpty(endereco.Estado) ? enderecoAtual.Estado : endereco.Estado;
            enderecoAtual.Bairro = string.IsNullOrEmpty(endereco.Bairro) ? enderecoAtual.Bairro : endereco.Bairro;
            enderecoAtual.Numero = endereco.Numero == 0 ? enderecoAtual.Numero : endereco.Numero;
            enderecoAtual.Complemento = string.IsNullOrEmpty(endereco.Complemento) ? enderecoAtual.Complemento : endereco.Complemento;
            enderecoAtual.Cep = string.IsNullOrEmpty(endereco.Cep) ? enderecoAtual.Cep : endereco.Cep;

            _dbSet.Update(enderecoAtual);
            if (_context.SaveChanges() > 0)
                return string.Empty;

            return "Erro ao atualizar o endereço";
        }

        public bool RemoverEndereco(int id)
        {
            var endereco = _dbSet.Find(id);

            if (endereco == null)
                return false;

            _dbSet.Remove(endereco);
            return _context.SaveChanges() > 0;
        }
    }
}