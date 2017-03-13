namespace ExcellProtecaoVeicular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryMigration1 : DbMigration
    {
        public override void Up() 
        {
            AlterColumn("dbo.Usuarios", "TipoUsuario", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "TipoUsuario", c => c.Int());
        }
    }
}
