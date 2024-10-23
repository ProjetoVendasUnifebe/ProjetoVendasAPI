using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Domain.DTOs
{
    public class ProdutoMaisVendidoOutputDTO
    {
        public IEnumerable<ProdutoMaisVendidoDTO> ProdutosMaisVendidos { get; set; }
        public ProdutoMaisVendidoOutputDTO(IEnumerable<ProdutoMaisVendidoDTO> produtoVendidos)
        {
            var objValueLista = new List<ProdutoMaisVendidoDTO>();

            foreach(var itens in produtoVendidos)
            {
                var objValue = new ProdutoMaisVendidoDTO()
                {
                    IdProduto = itens.IdProduto,
                    NomeProduto = itens.NomeProduto,
                    TotalVendido = itens.TotalVendido,
                };
                objValueLista.Add(objValue);

            }
            ProdutosMaisVendidos = objValueLista;

        }
    }


}
