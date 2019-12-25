namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizarNomeTipoDeSubscricao : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE TipoSubscricao SET Nome = 'Imediata' WHERE DuracaoEmMeses = 0;");
            Sql(@"UPDATE TipoSubscricao SET Nome = 'Mensal' WHERE DuracaoEmMeses = 1;");
            Sql(@"UPDATE TipoSubscricao SET Nome = 'Trimestral'WHERE DuracaoEmMeses = 3;");
            Sql(@"UPDATE TipoSubscricao SET Nome = 'Anual' WHERE DuracaoEmMeses = 12;");
        }
        
        public override void Down()
        {
        }
    }
}
