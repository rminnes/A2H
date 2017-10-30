namespace ATH.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listingimages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListingImage", "Listing_Id", c => c.Long());
            CreateIndex("dbo.ListingImage", "Listing_Id");
            AddForeignKey("dbo.ListingImage", "Listing_Id", "dbo.Listing", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListingImage", "Listing_Id", "dbo.Listing");
            DropIndex("dbo.ListingImage", new[] { "Listing_Id" });
            DropColumn("dbo.ListingImage", "Listing_Id");
        }
    }
}
