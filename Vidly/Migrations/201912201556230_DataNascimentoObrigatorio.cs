namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataNascimentoObrigatorio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "DataNascimento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cliente", "DataNascimento", c => c.DateTime());
        }
    }
}
