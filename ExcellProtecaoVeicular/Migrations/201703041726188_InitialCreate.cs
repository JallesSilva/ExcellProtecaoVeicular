namespace ExcellProtecaoVeicular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IDUsuarios = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        password = c.String(nullable: false),
                        TipoUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDUsuarios);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}
