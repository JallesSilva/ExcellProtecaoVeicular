namespace ExcellProtecaoVeicular.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryMigration3 : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IDCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Rg = c.String(),
                        DataNasci = c.DateTime(nullable: false),
                        Cnh = c.String(),
                        FK_Endereco = c.Int(),
                        FK_Telefone = c.Int(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IDCliente)
                .ForeignKey("dbo.Endereco", t => t.FK_Endereco)
                .ForeignKey("dbo.Telefone", t => t.FK_Telefone)
                .Index(t => t.FK_Endereco)
                .Index(t => t.FK_Telefone);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        IDEndereco = c.Int(nullable: false, identity: true),
                        Rua = c.String(),
                        Quadra = c.String(),
                        Lote = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        UF = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDEndereco);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        IDTelefone = c.Int(nullable: false, identity: true),
                        DDD = c.Int(nullable: false),
                        Tel_Casa = c.Int(nullable: false),
                        Tel_Celular = c.Int(nullable: false),
                        Tel_Recado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDTelefone);
            
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
            
            CreateTable(
                "dbo.Veiculos",
                c => new
                    {
                        IDVeiculos = c.Int(nullable: false, identity: true),
                        FK_Clientes = c.Int(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Placa = c.String(),
                    })
                .PrimaryKey(t => t.IDVeiculos)
                .ForeignKey("dbo.Clientes", t => t.FK_Clientes)
                .Index(t => t.FK_Clientes);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veiculos", "FK_Clientes", "dbo.Clientes");
            DropForeignKey("dbo.Beneficios", "FK_Cliente", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "FK_Telefone", "dbo.Telefone");
            DropForeignKey("dbo.Clientes", "FK_Endereco", "dbo.Endereco");
            DropIndex("dbo.Veiculos", new[] { "FK_Clientes" });
            DropIndex("dbo.Clientes", new[] { "FK_Telefone" });
            DropIndex("dbo.Clientes", new[] { "FK_Endereco" });
            DropIndex("dbo.Beneficios", new[] { "FK_Cliente" });
            DropTable("dbo.Veiculos");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Telefone");
            DropTable("dbo.Endereco");
            DropTable("dbo.Clientes");
            DropTable("dbo.Beneficios");
        }
    }
}
