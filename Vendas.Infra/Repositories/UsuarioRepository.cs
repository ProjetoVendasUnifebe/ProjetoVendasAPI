using Microsoft.EntityFrameworkCore;
using Vendas.Domain.Entities;
using Vendas.Domain.Interfaces;
using Vendas.Infra.Context;


namespace Vendas.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbSet<UsuarioModel> _dbSet;
        private readonly VendasDbContext _context;
        public UsuarioRepository(VendasDbContext context) 
        { 
            _context = context;
            _dbSet = context.Set<UsuarioModel>();
        }
        public List<UsuarioModel> BuscarUsuarios()
        {
            return _dbSet.ToList();
        }

        public bool CadastrarUsuario(UsuarioModel novoUsuario)
        {
             _dbSet.Add(novoUsuario);
            
            return _context.SaveChanges() > 0;
        }

        public UsuarioModel BuscarUsuarioPorLogin(string login) 
        {
            return _dbSet.FirstOrDefault(x => x.Login == login);

        }

        public UsuarioModel BuscarUsuarioPorId(int id)
        {
            return _dbSet.FirstOrDefault(x => x.IdUsuario == id);

        }

        public List<UsuarioModel> BuscarUsuarioPorNome(string nome)
        {
            return _dbSet.Where(x => EF.Functions.Like(x.NomeUsuario.ToLower(), $"%{nome.ToLower()}%")).ToList();

        }

        public string AtualizarUsuario(UsuarioModel usuarioAtualizado)
        {
            var usuario = BuscarUsuarioPorId(usuarioAtualizado.IdUsuario);
            if (usuario == null)
                return "Usuario não encontrado";

            if (_dbSet.Any(x => x.Login == usuarioAtualizado.Login))
                return "O login já está em uso por outro usuário";

            usuario.NomeUsuario = string.IsNullOrEmpty(usuarioAtualizado.NomeUsuario) ? usuario.NomeUsuario : usuarioAtualizado.NomeUsuario;
            usuario.EhAdm = usuarioAtualizado.EhAdm != 0 ? 1 : usuarioAtualizado.EhAdm;
            usuario.Login = string.IsNullOrEmpty(usuarioAtualizado.Login) ? usuario.Login : usuarioAtualizado.Login;
            
            _dbSet.Update(usuario);
            if (_context.SaveChanges() > 0)
                return string.Empty;

            return "Erro interno do servidor";
        }

        public string AtuaizarSenhaUsuario(string login, string senha)
        {
            var usuario = BuscarUsuarioPorLogin(login);
            if (usuario == null)
                return "Usuario não encontrado";

            usuario.Senha = senha;
            _dbSet.Update(usuario);
            if (_context.SaveChanges() > 0)
                return string.Empty;

            return "Erro interno do servidor";
        }

        public bool RemoverUsuario (int id)
        {
            var usuario = BuscarUsuarioPorId(id);
            if (usuario == null)
                return false;

            _dbSet.Remove(usuario);
            return _context.SaveChanges() > 0;

        }


    }
}
