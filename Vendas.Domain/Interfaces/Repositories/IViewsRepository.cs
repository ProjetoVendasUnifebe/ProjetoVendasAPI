using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.DTOs.ViewsDto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vendas.Domain.Interfaces.Repositories
{
    public interface IViewsRepository
    {
        IEnumerable<ClientesComComprasDTO> BuscaClientesComCompras(string? nomeCliente);
        IEnumerable<ProdutosVendidosDTO> BuscarProdutosVendidos(string? nomeProduto);
        IEnumerable<FaturamentoDTO> BuscarFaturamento(int mes, int ano);
        IEnumerable<VendasRealizadasDTO> BuscarVendasRealizadas();
    }
}
