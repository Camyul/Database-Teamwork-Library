namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author_Id = c.Int(),
                        BooksOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .ForeignKey("dbo.BooksOrders", t => t.BooksOrder_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.BooksOrder_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentGenres_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.ParentGenres_Id)
                .Index(t => t.ParentGenres_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Adrress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adrresses", t => t.Adrress_Id)
                .Index(t => t.Adrress_Id);
            
            CreateTable(
                "dbo.Adrresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostalCode = c.Int(nullable: false),
                        AdrressLine = c.String(),
                        Town_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towns", t => t.Town_Id)
                .Index(t => t.Town_Id);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BooksOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.GenreBooks",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Book_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BooksOrders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Books", "BooksOrder_Id", "dbo.BooksOrders");
            DropForeignKey("dbo.Users", "Adrress_Id", "dbo.Adrresses");
            DropForeignKey("dbo.Towns", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Adrresses", "Town_Id", "dbo.Towns");
            DropForeignKey("dbo.Genres", "ParentGenres_Id", "dbo.Genres");
            DropForeignKey("dbo.GenreBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.GenreBooks", new[] { "Book_Id" });
            DropIndex("dbo.GenreBooks", new[] { "Genre_Id" });
            DropIndex("dbo.BooksOrders", new[] { "User_Id" });
            DropIndex("dbo.Towns", new[] { "Country_Id" });
            DropIndex("dbo.Adrresses", new[] { "Town_Id" });
            DropIndex("dbo.Users", new[] { "Adrress_Id" });
            DropIndex("dbo.Orders", new[] { "Book_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Genres", new[] { "ParentGenres_Id" });
            DropIndex("dbo.Books", new[] { "BooksOrder_Id" });
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropTable("dbo.GenreBooks");
            DropTable("dbo.BooksOrders");
            DropTable("dbo.Countries");
            DropTable("dbo.Towns");
            DropTable("dbo.Adrresses");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
