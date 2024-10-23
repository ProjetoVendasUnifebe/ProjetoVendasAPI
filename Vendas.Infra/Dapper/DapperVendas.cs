using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.Interfaces.Dapper;

namespace Vendas.Infra.Dapper
{
    public class DapperVendas : IDapperVendas
    {
        private readonly IDbConnection _sqlConnection;

        public DapperVendas(IDbConnection connection)
        {
            _sqlConnection = connection;
        }

        public T QueryFirstOrDefaultVendas<T>(string query, object parametros = null)
        {
            return _sqlConnection.QueryFirstOrDefault<T>(query, parametros);
        }

        public IEnumerable<T> RunQueryVendas<T>(string query, object parametros = null)
        {
            return _sqlConnection.Query<T>(query, parametros);
        }
    }
}
