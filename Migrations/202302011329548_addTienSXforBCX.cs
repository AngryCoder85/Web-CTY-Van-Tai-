namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTienSXforBCX : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaoCaoXes", "Tien", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BaoCaoXes", "Tien");
        }
    }
}
