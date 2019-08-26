using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC_Beatriz.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string NumeroCartao { get; set; }

    }
}