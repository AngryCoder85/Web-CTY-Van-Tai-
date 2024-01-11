namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KHagainnn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChuyenXes", "Thu", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChuyenXes", "Thu", c => c.Long(nullable: false));
        }
    }
}
