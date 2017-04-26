namespace ExcellProtecaoVeicular.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryMigration2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Clientes", name: "Endereco_IDEndereco", newName: "FK_Endereco");
            RenameColumn(table: "dbo.Clientes", name: "Telefone_IDTelefone", newName: "FK_Telefone");
            RenameIndex(table: "dbo.Clientes", name: "IX_Endereco_IDEndereco", newName: "IX_FK_Endereco");
            RenameIndex(table: "dbo.Clientes", name: "IX_Telefone_IDTelefone", newName: "IX_FK_Telefone");
            CreateTable(
                "dbo.Beneficios",
                c => new
                    {
                        IDBeneficios = c.Int(nullable: false, identity: true),
                        FK_Cliente = c.Int(),
                        Horas_Veiculos = c.Boolean(nullable: false),
                        HorasAgregados = c.Boolean(nullable: false),
                        Vidros = c.Boolean(nullable: false),
                        CarroReserva = c.Boolean(nullable: false),
                        EnumDias = c.Int(nullable: false),
                        EnumFundo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDBeneficios)
                .ForeignKey("dbo.Clientes", t => t.FK_Cliente)
                .Index(t => t.FK_Cliente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beneficios", "FK_Cliente", "dbo.Clientes");
            DropIndex("dbo.Beneficios", new[] { "FK_Cliente" });
            DropTable("dbo.Beneficios");
            RenameIndex(table: "dbo.Clientes", name: "IX_FK_Telefone", newName: "IX_Telefone_IDTelefone");
            RenameIndex(table: "dbo.Clientes", name: "IX_FK_Endereco", newName: "IX_Endereco_IDEndereco");
            RenameColumn(table: "dbo.Clientes", name: "FK_Telefone", newName: "Telefone_IDTelefone");
            RenameColumn(table: "dbo.Clientes", name: "FK_Endereco", newName: "Endereco_IDEndereco");
        }
    }
}
