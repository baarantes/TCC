namespace TCC_Beatriz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ItemPedidoes", "ProdutoId");
            AddForeignKey("dbo.ItemPedidoes", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPedidoes", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.ItemPedidoes", new[] { "ProdutoId" });
        }
    }
}
