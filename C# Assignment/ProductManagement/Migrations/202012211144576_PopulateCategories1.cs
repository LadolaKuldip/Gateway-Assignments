namespace ProductManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategories1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES ('electronics')");
            Sql("INSERT INTO Categories (Name) VALUES ('Home Appliances')");
        }
        
        public override void Down()
        {
        }
    }
}
