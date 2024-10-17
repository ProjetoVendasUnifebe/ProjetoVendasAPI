using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Domain.DTOs;
using Vendas.Domain.Entities;

namespace Vendas.Domain.Interfaces
{
    public interface IItensVendidosRepository
    {
        List<ItensVendidosModel> BuscarTodosItensVendidos();
        ItensVendidosModel BuscarItensVendidosPorId(int id);
        bool CadastrarItensVendidos(ItensVendidosModel novoItensVendidos);
        string AtualizarItensVendidos(int id, ItensVendidosModel novoItensVendidos);
        bool RemoverItensVendidos(int id);


    }
}
