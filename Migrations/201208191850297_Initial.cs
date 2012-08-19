namespace bbqbank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WhoPaid = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CreatedAtUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HasTaxes = c.Boolean(nullable: false),
                        HasAlexisUsed = c.Boolean(nullable: false),
                        HasAudeUsed = c.Boolean(nullable: false),
                        HasMartinUsed = c.Boolean(nullable: false),
                        BillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bills", t => t.BillId, cascadeDelete: true)
                .Index(t => t.BillId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Items", new[] { "BillId" });
            DropForeignKey("dbo.Items", "BillId", "dbo.Bills");
            DropTable("dbo.Items");
            DropTable("dbo.Bills");
        }
    }
}
