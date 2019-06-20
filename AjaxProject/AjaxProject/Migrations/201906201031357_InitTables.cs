namespace AjaxProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarMarkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CarMarka_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarMarkas", t => t.CarMarka_Id)
                .Index(t => t.CarMarka_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarModels", "CarMarka_Id", "dbo.CarMarkas");
            DropIndex("dbo.CarModels", new[] { "CarMarka_Id" });
            DropTable("dbo.CarModels");
            DropTable("dbo.CarMarkas");
        }
    }
}
