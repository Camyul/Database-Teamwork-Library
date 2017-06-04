namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAtributestoModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.Users", "Adrress_Id", "dbo.Adrresses");
            DropForeignKey("dbo.Towns", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropIndex("dbo.Users", new[] { "Adrress_Id" });
            DropIndex("dbo.Towns", new[] { "Country_Id" });
            AlterColumn("dbo.Authors", "FirstName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Authors", "LastName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Books", "Author_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "FullName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Adrress_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Adrresses", "AdrressLine", c => c.String(nullable: false, unicode: false, storeType: "text"));
            AlterColumn("dbo.Towns", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Towns", "Country_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 60));
            CreateIndex("dbo.Books", "Author_Id");
            CreateIndex("dbo.Users", "Adrress_Id");
            CreateIndex("dbo.Towns", "Country_Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Authors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Adrress_Id", "dbo.Adrresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Towns", "Country_Id", "dbo.Countries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Towns", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Users", "Adrress_Id", "dbo.Adrresses");
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Towns", new[] { "Country_Id" });
            DropIndex("dbo.Users", new[] { "Adrress_Id" });
            DropIndex("dbo.Books", new[] { "Author_Id" });
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Towns", "Country_Id", c => c.Int());
            AlterColumn("dbo.Towns", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Adrresses", "AdrressLine", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Users", "Adrress_Id", c => c.Int());
            AlterColumn("dbo.Users", "FullName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Genres", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Books", "Author_Id", c => c.Int());
            AlterColumn("dbo.Authors", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "FirstName", c => c.String(nullable: false));
            CreateIndex("dbo.Towns", "Country_Id");
            CreateIndex("dbo.Users", "Adrress_Id");
            CreateIndex("dbo.Books", "Author_Id");
            AddForeignKey("dbo.Towns", "Country_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.Users", "Adrress_Id", "dbo.Adrresses", "Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
