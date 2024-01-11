namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addXe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Xes",
                c => new
                    {
                        XeId = c.Long(nullable: false, identity: true),
                        XeName = c.String(nullable: false),
                        BSXe = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.XeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Xes");
        }
    }
}
