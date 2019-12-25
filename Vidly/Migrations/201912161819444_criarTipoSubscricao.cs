namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criarTipoSubscricao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoSubscricao",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TaxaInscricao = c.Int(nullable: false),
                        DuracaoEmMeses = c.Byte(nullable: false),
                        PercentualDesconto = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cliente", "TipoSubscricaoId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Cliente", "TipoSubscricaoId");
            AddForeignKey("dbo.Cliente", "TipoSubscricaoId", "dbo.TipoSubscricao", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "TipoSubscricaoId", "dbo.TipoSubscricao");
            DropIndex("dbo.Cliente", new[] { "TipoSubscricaoId" });
            DropColumn("dbo.Cliente", "TipoSubscricaoId");
            DropTable("dbo.TipoSubscricao");
        }
    }
}
