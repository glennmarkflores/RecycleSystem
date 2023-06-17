namespace RecycleSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.TypeModels", "Ix_Type");
            DropTable("dbo.TypeModels");
        }
    }
}
