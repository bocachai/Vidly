namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Description", c => c.String(maxLength: 100));
            Sql("update membershiptypes set Description = 'Pay As You Go' where Id = 1");
            Sql("update membershiptypes set Description = 'Monthly' where Id = 2");
            Sql("update membershiptypes set Description = 'Quaterly' where Id = 3");
            Sql("update membershiptypes set Description = 'Annual' where Id = 4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Description");
        }
    }
}
