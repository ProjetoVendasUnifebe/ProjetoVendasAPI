using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.Interfaces.Dapper
{
    public interface IDapperVendas
    {
        T QueryFirstOrDefaultVendas<T>(string query, object parametros = null);
        IEnumerable<T> RunQueryVendas<T>(string query, object parametros = null);
    }
}
