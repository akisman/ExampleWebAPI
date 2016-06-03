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
                "dbo.PetWalkers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
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
                        PetWalkerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PetOwners", t => t.PetOwnerId, cascadeDelete: true)
                .ForeignKey("dbo.PetWalkers", t => t.PetWalkerId)
                .Index(t => t.PetOwnerId)
                .Index(t => t.PetWalkerId);
            
            CreateTable(
                "dbo.PetWalkerPetOwners",
                c => new
                    {
                        PetWalker_Id = c.Int(nullable: false),
                        PetOwner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PetWalker_Id, t.PetOwner_Id })
                .ForeignKey("dbo.PetWalkers", t => t.PetWalker_Id, cascadeDelete: true)
                .ForeignKey("dbo.PetOwners", t => t.PetOwner_Id, cascadeDelete: true)
                .Index(t => t.PetWalker_Id)
                .Index(t => t.PetOwner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "PetWalkerId", "dbo.PetWalkers");
            DropForeignKey("dbo.Pets", "PetOwnerId", "dbo.PetOwners");
            DropForeignKey("dbo.PetWalkerPetOwners", "PetOwner_Id", "dbo.PetOwners");
            DropForeignKey("dbo.PetWalkerPetOwners", "PetWalker_Id", "dbo.PetWalkers");
            DropIndex("dbo.PetWalkerPetOwners", new[] { "PetOwner_Id" });
            DropIndex("dbo.PetWalkerPetOwners", new[] { "PetWalker_Id" });
            DropIndex("dbo.Pets", new[] { "PetWalkerId" });
            DropIndex("dbo.Pets", new[] { "PetOwnerId" });
            DropTable("dbo.PetWalkerPetOwners");
            DropTable("dbo.Pets");
            DropTable("dbo.PetWalkers");
            DropTable("dbo.PetOwners");
        }
    }
}
