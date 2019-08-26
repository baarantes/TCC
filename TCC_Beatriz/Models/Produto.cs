using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC_Beatriz.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int QuantidadeEstoque { get; set; }

        public virtual Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}