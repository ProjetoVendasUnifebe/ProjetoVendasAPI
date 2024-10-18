using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Application.Interfaces
{
    public interface IItensVendidosService
    {
        List<ItensVendidosModel> BuscarTodosItensVendidos();
        ItensVendidosModel BuscarItensVendidosPorId(int id);
        bool CadastrarItensVendidos(ItensVendidosInputDTO novoItensVendidos);
        string AtualizarItensVendidos(int id, ItensVendidosInputDTO novoItensVendidos);
        bool RemoverItensVendidos(int id);
    }
}
