namespace ExcellProtecaoVeicular.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class History4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "DataNasci", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "DataNasci", c => c.DateTime(nullable: false));
        }
    }
}
