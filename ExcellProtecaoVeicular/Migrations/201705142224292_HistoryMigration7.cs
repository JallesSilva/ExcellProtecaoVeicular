namespace ExcellProtecaoVeicular.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryMigration7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Telefone", "Tel_Casa", c => c.String());
            AlterColumn("dbo.Telefone", "Tel_Celular", c => c.String());
            AlterColumn("dbo.Telefone", "Tel_Recado", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Telefone", "Tel_Recado", c => c.Int(nullable: false));
            AlterColumn("dbo.Telefone", "Tel_Celular", c => c.Int(nullable: false));
            AlterColumn("dbo.Telefone", "Tel_Casa", c => c.Int(nullable: false));
        }
    }
}
