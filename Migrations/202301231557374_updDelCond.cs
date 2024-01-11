namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updDelCond : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChuyenXes", "DelCond", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChuyenXes", "DelCond");
        }
    }
}
