namespace ATH.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listingdatenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Listing", "AvaiableDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Listing", "AvaiableDate", c => c.DateTime(nullable: false));
        }
    }
}
