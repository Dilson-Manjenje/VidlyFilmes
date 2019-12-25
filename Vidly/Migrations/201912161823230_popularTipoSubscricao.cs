namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class popularTipoSubscricao : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO TipoSubscricao(Id, TaxaInscricao, DuracaoEmMeses, PercentualDesconto) VALUES( NEWID(), 0, 0, 0)");
            Sql(@"INSERT INTO TipoSubscricao(Id, TaxaInscricao, DuracaoEmMeses, PercentualDesconto) VALUES( NEWID(), 30, 1, 10)");
            Sql(@"INSERT INTO TipoSubscricao(Id, TaxaInscricao, DuracaoEmMeses, PercentualDesconto) VALUES( NEWID(), 90, 3, 15)");
            Sql(@"INSERT INTO TipoSubscricao(Id, TaxaInscricao, DuracaoEmMeses, PercentualDesconto) VALUES( NEWID(), 250, 12, 20)");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM TipoSubscricao");
        }
    }
}
