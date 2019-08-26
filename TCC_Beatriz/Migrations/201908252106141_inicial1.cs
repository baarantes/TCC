namespace TCC_Beatriz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Produtoes", "CategoriaId");
            AddForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtoes", new[] { "CategoriaId" });
        }
    }
}
