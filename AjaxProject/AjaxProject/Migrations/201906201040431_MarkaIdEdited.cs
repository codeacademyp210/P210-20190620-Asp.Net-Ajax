namespace AjaxProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarkaIdEdited : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarModels", "CarMarka_Id", "dbo.CarMarkas");
            DropIndex("dbo.CarModels", new[] { "CarMarka_Id" });
            RenameColumn(table: "dbo.CarModels", name: "CarMarka_Id", newName: "CarMarkaID");
            AlterColumn("dbo.CarModels", "CarMarkaID", c => c.Int(nullable: false));
            CreateIndex("dbo.CarModels", "CarMarkaID");
            AddForeignKey("dbo.CarModels", "CarMarkaID", "dbo.CarMarkas", "Id", cascadeDelete: true);
            DropColumn("dbo.CarModels", "MarkaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarModels", "MarkaID", c => c.Int(nullable: false));
            DropForeignKey("dbo.CarModels", "CarMarkaID", "dbo.CarMarkas");
            DropIndex("dbo.CarModels", new[] { "CarMarkaID" });
            AlterColumn("dbo.CarModels", "CarMarkaID", c => c.Int());
            RenameColumn(table: "dbo.CarModels", name: "CarMarkaID", newName: "CarMarka_Id");
            CreateIndex("dbo.CarModels", "CarMarka_Id");
            AddForeignKey("dbo.CarModels", "CarMarka_Id", "dbo.CarMarkas", "Id");
        }
    }
}
