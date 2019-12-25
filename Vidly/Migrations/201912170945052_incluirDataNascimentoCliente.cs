namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incluirDataNascimentoCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cliente", "DataNascimento", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cliente", "DataNascimento");
        }
    }
}
