namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incluirNotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TipoSubscricao", "Nome", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Filme", "Nome", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Filme", "Nome", c => c.String());
            AlterColumn("dbo.TipoSubscricao", "Nome", c => c.String());
        }
    }
}
