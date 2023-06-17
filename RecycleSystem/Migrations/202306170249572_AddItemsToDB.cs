namespace RecycleSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemsToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecyclableTypeId = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ComputedRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemDescription = c.String(maxLength: 150),
                        TypeModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeModels", t => t.TypeModel_Id)
                .Index(t => t.TypeModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemModels", "TypeModel_Id", "dbo.TypeModels");
            DropIndex("dbo.ItemModels", new[] { "TypeModel_Id" });
            DropTable("dbo.ItemModels");
        }
    }
}
