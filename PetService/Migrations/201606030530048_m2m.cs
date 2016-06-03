namespace PetService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2m : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.PetWalkerPetOwners", "PetOwner_Id", "dbo.PetOwners");
            DropForeignKey("dbo.PetWalkerPetOwners", "PetWalker_Id", "dbo.PetWalkers");
            DropIndex("dbo.PetWalkerPetOwners", new[] { "PetOwner_Id" });
            DropIndex("dbo.PetWalkerPetOwners", new[] { "PetWalker_Id" });
            DropTable("dbo.PetWalkerPetOwners");
        }
    }
}
