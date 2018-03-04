namespace ATH.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listing", "Bedrooms", c => c.Int(nullable: false));
            AddColumn("dbo.Listing", "Furnished", c => c.Boolean(nullable: false));
            AddColumn("dbo.Listing", "AvaiableDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Listing", "Features", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Listing", "Features");
            DropColumn("dbo.Listing", "AvaiableDate");
            DropColumn("dbo.Listing", "Furnished");
            DropColumn("dbo.Listing", "Bedrooms");
        }
    }
}
