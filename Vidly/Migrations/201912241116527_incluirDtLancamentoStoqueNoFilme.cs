namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incluirDtLancamentoStoqueNoFilme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Filme", "DataLancamento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Filme", "QtdStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Filme", "QtdStock");
            DropColumn("dbo.Filme", "DataLancamento");
        }
    }
}
