namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incluirNome_TipoSubscricao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoSubscricao", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoSubscricao", "Nome");
        }
    }
}
