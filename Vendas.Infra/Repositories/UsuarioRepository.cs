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
    public class UsuarioRepository :  IUsuarioRepository
    {
        private readonly DbSet<UsuarioModel> _dbSet;

        public UsuarioRepository(VendasDbContext context) 
        {
            _dbSet = context.Set<UsuarioModel>();
        }

        public List<UsuarioModel> BuscarUsuarios()
        {
            return _dbSet.ToList();
        }

        public UsuarioModel BuscarUsuario(int id) 
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }
    }
}
