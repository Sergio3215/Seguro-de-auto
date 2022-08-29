namespace InsuranceCar_WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetailPolicy", "id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetailPolicy", "id");
        }
    }
}
