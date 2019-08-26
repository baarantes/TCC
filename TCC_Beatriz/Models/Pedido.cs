using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC_Beatriz.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string CPFCliente { get; set; }
    }
}