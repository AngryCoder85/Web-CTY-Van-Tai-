namespace CTY_DVVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delXeName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Xes", "XeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Xes", "XeName", c => c.String(nullable: false));
        }
    }
}
