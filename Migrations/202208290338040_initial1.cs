namespace InsuranceCar_WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DetailPolicy", "id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetailPolicy", "id", c => c.Int(nullable: false));
        }
    }
}
