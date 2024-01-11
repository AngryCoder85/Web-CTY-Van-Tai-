namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updXeid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BaoCaoXes", "Xe_XeId", "dbo.Xes");
            DropIndex("dbo.BaoCaoXes", new[] { "Xe_XeId" });
            DropColumn("dbo.BaoCaoXes", "XeId");
            RenameColumn(table: "dbo.BaoCaoXes", name: "Xe_XeId", newName: "XeId");
            AlterColumn("dbo.BaoCaoXes", "XeId", c => c.Long(nullable: false));
            AlterColumn("dbo.BaoCaoXes", "XeId", c => c.Long(nullable: false));
            CreateIndex("dbo.BaoCaoXes", "XeId");
            AddForeignKey("dbo.BaoCaoXes", "XeId", "dbo.Xes", "XeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BaoCaoXes", "XeId", "dbo.Xes");
            DropIndex("dbo.BaoCaoXes", new[] { "XeId" });
            AlterColumn("dbo.BaoCaoXes", "XeId", c => c.Long());
            AlterColumn("dbo.BaoCaoXes", "XeId", c => c.String(nullable: false));
            RenameColumn(table: "dbo.BaoCaoXes", name: "XeId", newName: "Xe_XeId");
            AddColumn("dbo.BaoCaoXes", "XeId", c => c.String(nullable: false));
            CreateIndex("dbo.BaoCaoXes", "Xe_XeId");
            AddForeignKey("dbo.BaoCaoXes", "Xe_XeId", "dbo.Xes", "XeId");
        }
    }
}
