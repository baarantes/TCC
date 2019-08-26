using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC_Beatriz.Models
{
    public class Carrinho
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
    }
}