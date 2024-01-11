namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTSX : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChuyenXes", "TienSuaXe", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChuyenXes", "TienSuaXe");
        }
    }
}
