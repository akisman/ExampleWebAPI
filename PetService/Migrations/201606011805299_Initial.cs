namespace PetService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PetOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(),
                        PetOwnerId = c.Int(nullable: false),
                        PetWalkerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PetOwners", t => t.PetOwnerId, cascadeDelete: true)
                .ForeignKey("dbo.PetWalkers", t => t.PetWalkerId, cascadeDelete: true)
                .Index(t => t.PetOwnerId)
                .Index(t => t.PetWalkerId);
            
            CreateTable(
                "dbo.PetWalkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "PetWalkerId", "dbo.PetWalkers");
            DropForeignKey("dbo.Pets", "PetOwnerId", "dbo.PetOwners");
            DropIndex("dbo.Pets", new[] { "PetWalkerId" });
            DropIndex("dbo.Pets", new[] { "PetOwnerId" });
            DropTable("dbo.PetWalkers");
            DropTable("dbo.Pets");
            DropTable("dbo.PetOwners");
        }
    }
}
