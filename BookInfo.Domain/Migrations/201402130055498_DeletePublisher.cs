namespace BookInfo.Domain.Concrete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePublisher : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "Publisher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Publisher", c => c.String());
        }
    }
}
