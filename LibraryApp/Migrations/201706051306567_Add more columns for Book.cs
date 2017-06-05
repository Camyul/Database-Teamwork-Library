namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddmorecolumnsforBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Price");
            DropColumn("dbo.Books", "Year");
        }
    }
}
