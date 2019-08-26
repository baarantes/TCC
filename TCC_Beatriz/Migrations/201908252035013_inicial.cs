namespace TCC_Beatriz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPF = c.String(unicode: false),
                        Nome = c.String(unicode: false),
                        Endereço = c.String(unicode: false),
                        Municipio = c.String(unicode: false),
                        Telefone = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Senha = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistoricoEstoques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProdutoId = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false, precision: 0),
                        Quantidade = c.Int(nullable: false),
                        TipoMovimentoEstoque = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemPedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotaFiscals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        PedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pagamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false, precision: 0),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumeroCartao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        CPFCliente = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(unicode: false),
                        Nome = c.String(unicode: false),
                        QuantidadeEstoque = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produtoes");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Pagamentoes");
            DropTable("dbo.NotaFiscals");
            DropTable("dbo.ItemPedidoes");
            DropTable("dbo.HistoricoEstoques");
            DropTable("dbo.Clientes");
            DropTable("dbo.Categorias");
        }
    }
}
