namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updXeidagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaoCaoXes", "NgayThang", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BaoCaoXes", "NgayThang");
        }
    }
}
