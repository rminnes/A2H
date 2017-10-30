namespace ATH.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListingImage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FileLocation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Listing",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        Price = c.Int(nullable: false),
                        Postcode = c.String(),
                        LatLong = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Listing");
            DropTable("dbo.ListingImage");
        }
    }
}
