using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IVendaRepository
    {
        List<VendaModel> BuscarVendas();
        List<VendaModel> BuscarVendasPorData(DateTime? dataInicio, DateTime? dataFim);
        bool CadastrarVenda(VendaModel novaVenda);
        string AtualizarVenda(VendaModel novaVenda);
        bool RemoverVenda(int id);
        VendaModel BuscarVendaPorId(int id);
    }
}
