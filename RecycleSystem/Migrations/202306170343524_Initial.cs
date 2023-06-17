namespace RecycleSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeModelId = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ComputedRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDescription = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeModels", t => t.TypeModelId, cascadeDelete: true)
                .Index(t => t.TypeModelId);
            
            CreateTable(
                "dbo.TypeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 100),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinKg = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxKg = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Type, unique: true, name: "Ix_Type");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemModels", "TypeModelId", "dbo.TypeModels");
            DropIndex("dbo.TypeModels", "Ix_Type");
            DropIndex("dbo.ItemModels", new[] { "TypeModelId" });
            DropTable("dbo.TypeModels");
            DropTable("dbo.ItemModels");
        }
    }
}
