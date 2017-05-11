namespace ExcellProtecaoVeicular.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryMigration6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beneficios", "FundoParaTerceiros", c => c.Boolean(nullable: false));
            AddColumn("dbo.Beneficios", "ListaItensDeCarrosReserva", c => c.String());
            AddColumn("dbo.Veiculos", "EnumTipoDeVeiculos", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Veiculos", "EnumTipoDeVeiculos");
            DropColumn("dbo.Beneficios", "ListaItensDeCarrosReserva");
            DropColumn("dbo.Beneficios", "FundoParaTerceiros");
        }
    }
}
