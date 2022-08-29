namespace InsuranceCar_WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoverageInsurance",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.DetailPolicy",
                c => new
                {
                    id = c.Int(nullable: false),
                    id_catalog = c.Int(nullable: false, identity: true),
                    name = c.String(nullable: false),
                    name_catalog = c.String(nullable: false),
                    insured_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.id_catalog);
        }
        
        public override void Down()
        {
            DropTable("dbo.DetailPolicy");
            DropTable("dbo.CoverageInsurance");
        }
    }
}
