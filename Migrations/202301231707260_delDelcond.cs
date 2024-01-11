namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delDelcond : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ChuyenXes", "DelCond");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChuyenXes", "DelCond", c => c.Boolean(nullable: false));
        }
    }
}
