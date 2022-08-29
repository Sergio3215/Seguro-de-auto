namespace InsuranceCar_WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changekeyx2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DetailPolicy");
            AlterColumn("dbo.DetailPolicy", "id_catalog", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailPolicy", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DetailPolicy", "id");
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.DetailPolicy");
            AlterColumn("dbo.DetailPolicy", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.DetailPolicy", "id_catalog", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DetailPolicy", "id_catalog");
        }
    }
}
