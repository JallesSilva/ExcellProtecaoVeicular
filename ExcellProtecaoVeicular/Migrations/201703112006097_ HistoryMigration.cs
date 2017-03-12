namespace ExcellProtecaoVeicular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IDCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.Int(nullable: false),
                        Rg = c.Int(nullable: false),
                        DataNasci = c.DateTime(nullable: false),
                        Cnh = c.String(),
                        Email = c.String(),
                        Endereco_IDEndereco = c.Int(),
                        Telefone_IDTelefone = c.Int(),
                    })
                .PrimaryKey(t => t.IDCliente)
                .ForeignKey("dbo.Endereco", t => t.Endereco_IDEndereco)
                .ForeignKey("dbo.Telefone", t => t.Telefone_IDTelefone)
                .Index(t => t.Endereco_IDEndereco)
                .Index(t => t.Telefone_IDTelefone);
            
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
            DropForeignKey("dbo.Clientes", "Telefone_IDTelefone", "dbo.Telefone");
            DropForeignKey("dbo.Clientes", "Endereco_IDEndereco", "dbo.Endereco");
            DropIndex("dbo.Veiculos", new[] { "FK_Clientes" });
            DropIndex("dbo.Clientes", new[] { "Telefone_IDTelefone" });
            DropIndex("dbo.Clientes", new[] { "Endereco_IDEndereco" });
            DropTable("dbo.Veiculos");
            DropTable("dbo.Telefone");
            DropTable("dbo.Endereco");
            DropTable("dbo.Clientes");
        }
    }
}
