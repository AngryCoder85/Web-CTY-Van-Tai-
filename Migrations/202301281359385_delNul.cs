namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delNul : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChuyenXes", "TienConLai", c => c.Long(nullable: false));
            AlterColumn("dbo.ChuyenXes", "Thu", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChuyenXes", "Thu", c => c.Long());
            AlterColumn("dbo.ChuyenXes", "TienConLai", c => c.Long());
        }
    }
}
