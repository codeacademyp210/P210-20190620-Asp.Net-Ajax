namespace AjaxProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarkaIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarModels", "MarkaID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarModels", "MarkaID");
        }
    }
}
