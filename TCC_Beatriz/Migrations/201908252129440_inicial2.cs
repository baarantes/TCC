namespace TCC_Beatriz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.HistoricoEstoques", "ProdutoId");
            AddForeignKey("dbo.HistoricoEstoques", "ProdutoId", "dbo.Produtoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoricoEstoques", "ProdutoId", "dbo.Produtoes");
            DropIndex("dbo.HistoricoEstoques", new[] { "ProdutoId" });
        }
    }
}
