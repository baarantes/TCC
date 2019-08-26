using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TCC_Beatriz.Models;

namespace TCC_Beatriz
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnectionSQL")
        {
            this.Database.Log = message => Debug.WriteLine(message);
        }

        public static DataContext Create()
        {
            return new DataContext();
        }

        public DataContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<HistoricoEstoque> HistoricosMovimentoEstoque { get; set; }
    }
}