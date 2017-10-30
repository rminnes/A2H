namespace ATH.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddlettingAgents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LettingAgent",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Address_1 = c.String(),
                        Address_2 = c.String(),
                        Address_3 = c.String(),
                        Postcode = c.String(),
                        Phone = c.String(),
                        Description = c.String(),
                        Logo = c.String(),
                        Website = c.String(),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Listing", "Agent_Id", c => c.Long());
            CreateIndex("dbo.Listing", "Agent_Id");
            AddForeignKey("dbo.Listing", "Agent_Id", "dbo.LettingAgent", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Listing", "Agent_Id", "dbo.LettingAgent");
            DropIndex("dbo.Listing", new[] { "Agent_Id" });
            DropColumn("dbo.Listing", "Agent_Id");
            DropTable("dbo.LettingAgent");
        }
    }
}
