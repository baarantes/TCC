using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC_Beatriz.Models
{
    public class HistoricoEstoque
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public TipoMovimentoEstoque TipoMovimentoEstoque { get; set; }

    }

    public enum TipoMovimentoEstoque {
        Entrada = 0,
        Saida = 1
    }
}