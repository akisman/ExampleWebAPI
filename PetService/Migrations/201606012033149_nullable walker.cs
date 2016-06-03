namespace PetService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablewalker : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pets", "PetWalkerId", "dbo.PetWalkers");
            DropIndex("dbo.Pets", new[] { "PetWalkerId" });
            AlterColumn("dbo.Pets", "PetWalkerId", c => c.Int());
            CreateIndex("dbo.Pets", "PetWalkerId");
            AddForeignKey("dbo.Pets", "PetWalkerId", "dbo.PetWalkers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "PetWalkerId", "dbo.PetWalkers");
            DropIndex("dbo.Pets", new[] { "PetWalkerId" });
            AlterColumn("dbo.Pets", "PetWalkerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pets", "PetWalkerId");
            AddForeignKey("dbo.Pets", "PetWalkerId", "dbo.PetWalkers", "Id", cascadeDelete: true);
        }
    }
}
