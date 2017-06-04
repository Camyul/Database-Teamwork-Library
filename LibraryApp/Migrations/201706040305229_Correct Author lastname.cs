namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectAuthorlastname : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "LastName", c => c.Int(nullable: false));
        }
    }
}
