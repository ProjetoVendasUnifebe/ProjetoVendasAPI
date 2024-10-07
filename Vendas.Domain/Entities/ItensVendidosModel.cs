namespace Vendas.Domain.Entities
{
    public class ItensVendidosModel
    {
        public int IdItensVendidos { get; set; }
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public int QtdVendida { get; set; }
    }
}