using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IVendaService
    {
        List<VendaModel> BuscarTodos();
        List<VendaModel> BuscarVendasPorData(DateTime? dataInicio, DateTime? dataFim);
        bool CadastrarVenda(VendaInputDTO novaVenda);
        string AtualizarVenda(int id, VendaAtualizaInputDTO novaVenda);
        bool RemoverVenda(int id);
        VendaModel BuscarVendaPorId(int id);
    }
}
