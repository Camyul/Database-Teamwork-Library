namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addconstraints : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "Book_Id", "dbo.Books");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "Book_Id" });
            RenameColumn(table: "dbo.Books", name: "BooksOrder_Id", newName: "Order_Id");
            RenameIndex(table: "dbo.Books", name: "IX_BooksOrder_Id", newName: "IX_Order_Id");
            AddColumn("dbo.Books", "Description", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Authors", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Genres", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "FullName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Adrresses", "AdrressLine", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Towns", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false));
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Countries", "Name", c => c.String());
            AlterColumn("dbo.Towns", "Name", c => c.String());
            AlterColumn("dbo.Adrresses", "AdrressLine", c => c.String());
            AlterColumn("dbo.Users", "FullName", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
            AlterColumn("dbo.Authors", "LastName", c => c.String());
            AlterColumn("dbo.Authors", "FirstName", c => c.String());
            DropColumn("dbo.Books", "Description");
            RenameIndex(table: "dbo.Books", name: "IX_Order_Id", newName: "IX_BooksOrder_Id");
            RenameColumn(table: "dbo.Books", name: "Order_Id", newName: "BooksOrder_Id");
            CreateIndex("dbo.Orders", "Book_Id");
            CreateIndex("dbo.Orders", "User_Id");
            AddForeignKey("dbo.Orders", "Book_Id", "dbo.Books", "Id");
            AddForeignKey("dbo.Orders", "User_Id", "dbo.Users", "Id");
        }
    }
}
