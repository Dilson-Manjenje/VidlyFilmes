namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incluirGeneroFilme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Filme", "GeneroId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Filme", "GeneroId");
            AddForeignKey("dbo.Filme", "GeneroId", "dbo.Genero", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Filme", "GeneroId", "dbo.Genero");
            DropIndex("dbo.Filme", new[] { "GeneroId" });
            DropColumn("dbo.Filme", "GeneroId");
            DropTable("dbo.Genero");
        }
    }
}
