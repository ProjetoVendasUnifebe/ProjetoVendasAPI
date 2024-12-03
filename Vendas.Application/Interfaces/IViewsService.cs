﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.DTOs.ViewsDto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vendas.Application.Interfaces
{
    public interface IViewsService
    {
        IEnumerable<ClientesComComprasDTO> BuscaClientesComCompras(int ordenacao, string? nomeCliente);
        IEnumerable<ProdutosVendidosDTO> BuscarProdutosVendidos(int ordenacao, string? nomeProduto);
        IEnumerable<FaturamentoDTO> BuscarFaturamento(int mes, int ano);
        IEnumerable<VendasRealizadasDTO> BuscarVendasRealizadas();
    }
}
