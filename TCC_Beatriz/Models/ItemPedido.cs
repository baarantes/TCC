using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC_Beatriz.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}