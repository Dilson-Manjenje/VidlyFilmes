namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class popularGenero : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Genero(Id, Descricao) VALUES( NEWID(), 'Comedia')");
            Sql(@"INSERT INTO Genero(Id, Descricao) VALUES( NEWID(), 'Acao')");
            Sql(@"INSERT INTO Genero(Id, Descricao) VALUES( NEWID(), 'Drama')");
            Sql(@"INSERT INTO Genero(Id, Descricao) VALUES( NEWID(), 'Documentario')");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM Genero");
        }
    }
}
