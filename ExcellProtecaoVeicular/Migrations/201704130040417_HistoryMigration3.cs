namespace ExcellProtecaoVeicular.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryMigration3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Cpf", c => c.String());
            AlterColumn("dbo.Clientes", "Rg", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Rg", c => c.Int(nullable: false));
            AlterColumn("dbo.Clientes", "Cpf", c => c.Int(nullable: false));
        }
    }
}
