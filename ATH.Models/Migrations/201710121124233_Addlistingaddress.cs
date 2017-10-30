namespace ATH.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addlistingaddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listing", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Listing", "Address");
        }
    }
}
