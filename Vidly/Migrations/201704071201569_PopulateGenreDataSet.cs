namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreDataSet : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Sci-Fi')");
        }
        
        public override void Down()
        {
        }
    }
}
