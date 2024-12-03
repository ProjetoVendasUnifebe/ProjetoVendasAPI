using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Application.Interfaces;
using Vendas.Domain.DTOs.ViewsDto;
using Vendas.Domain.Interfaces.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vendas.Application.Services
{
    public class ViewsService : IViewsService
    {
        private readonly IViewsRepository _viewsRepository;
        public ViewsService(IViewsRepository viewsRepository)
        {
            _viewsRepository = viewsRepository;
        }

        public IEnumerable<ClientesComComprasDTO> BuscaClientesComCompras(int ordenacao, string? nomeCliente)
        {
            if (ordenacao == 0)
                return _viewsRepository.BuscaClientesComCompras(nomeCliente).OrderBy(c => c.numeroDeCompras);
            
                return _viewsRepository.BuscaClientesComCompras(nomeCliente).OrderByDescending(c => c.numeroDeCompras);
            
        }

        public IEnumerable<ProdutosVendidosDTO> BuscarProdutosVendidos(int ordenacao, string? nomeProduto)
        {
            if (ordenacao == 0)
                return _viewsRepository.BuscarProdutosVendidos(nomeProduto).OrderBy(c => c.ValorTotal);

                return _viewsRepository.BuscarProdutosVendidos(nomeProduto).OrderByDescending(c => c.ValorTotal);
        }

        public IEnumerable<FaturamentoDTO> BuscarFaturamento(int mes, int ano)
        {
            return _viewsRepository.BuscarFaturamento(mes, ano);
        }

        public IEnumerable<VendasRealizadasDTO> BuscarVendasRealizadas()
        {
            return _viewsRepository.BuscarVendasRealizadas();
        }
    }
}
