using Dapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.DTOs;
using Vendas.Domain.DTOs.ViewsDto;
using Vendas.Domain.Interfaces.Dapper;
using Vendas.Domain.Interfaces.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vendas.Infra.Repositories
{
    public class ViewsRepository : IViewsRepository
    {
        private readonly IDapperVendas _dapperVendas;

        public ViewsRepository(IDapperVendas dapperVendas)
        {
            _dapperVendas = dapperVendas;
        }
        public IEnumerable<ClientesComComprasDTO> BuscaClientesComCompras(string? nomeCliente)
        {
            var filtro = "";

            if (nomeCliente != null)
                filtro += $@"WHERE cliente_nome LIKE '%{nomeCliente.ToLower()}%'";
            

            var query = $@"SELECT ""idCliente"" AS idCliente, 
                            UPPER(cliente_nome) AS nomeCliente, 
                            numero_compras AS numeroDeCompras, 
                            total_compras AS totalDasCompras
	                   FROM comercialize.vw_clientes_com_compras 
                                {filtro} ;";

            return _dapperVendas.RunQueryVendas<ClientesComComprasDTO>(query);
        }

        public IEnumerable<ProdutosVendidosDTO> BuscarProdutosVendidos(string? nomeProduto)
        {
            var filtro = "";

            if (nomeProduto != null)
                filtro += $@"WHERE produto_nome LIKE '%{nomeProduto.ToLower()}%'";
            
            var query = $@"SELECT ""idProduto"" AS IdProduto, 
                            UPPER(produto_nome) AS NomeProduto, 
                            quantidade_vendida AS QuantidadeVendida, 
                            total_vendas AS ValorTotal
                         FROM comercialize.vw_produtos_vendidos
                                {filtro};";

            return _dapperVendas.RunQueryVendas<ProdutosVendidosDTO>(query);
        }

        public IEnumerable<FaturamentoDTO> BuscarFaturamento(int mes, int ano)
        {
            var filtros = new List<string>();

            if (ano != 0)
                filtros.Add($"ano = {ano}");

            if (mes != 0)
                filtros.Add($"mes = {mes}");

            var filtroFinal = filtros.Any() ? "WHERE " + string.Join(" AND ", filtros) : "";

            var query = $@"
                        SELECT mes AS Mes, 
                             ano AS Ano, 
                            faturamento AS Faturamento
                        FROM comercialize.vw_faturamento_mensal
                            {filtroFinal};";

            return _dapperVendas.RunQueryVendas<FaturamentoDTO>(query);
        }

        public IEnumerable<VendasRealizadasDTO> BuscarVendasRealizadas()
        {

                var query = $@"
            SELECT cliente AS NomeCliente, 
                  email AS Email, 
                  data_venda AS DataVenda, 
                 valor_venda AS ValorDaVenda
            FROM comercialize.vw_vendas_realizadas;";

           return _dapperVendas.RunQueryVendas<VendasRealizadasDTO>(query);
        }


    }
}
