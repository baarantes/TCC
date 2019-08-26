using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC_Beatriz.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Endereço { get; set; }
        public string Municipio { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}