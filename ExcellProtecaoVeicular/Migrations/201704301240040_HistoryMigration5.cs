namespace ExcellProtecaoVeicular.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryMigration5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FK_Clientes = c.Int(),
                        NameImage = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.FK_Clientes)
                .Index(t => t.FK_Clientes);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "FK_Clientes", "dbo.Clientes");
            DropIndex("dbo.Image", new[] { "FK_Clientes" });
            DropTable("dbo.Image");
        }
    }
}
