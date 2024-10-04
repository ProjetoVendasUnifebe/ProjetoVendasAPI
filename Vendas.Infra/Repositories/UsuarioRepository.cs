using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
