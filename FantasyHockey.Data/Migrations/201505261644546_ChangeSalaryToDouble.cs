using System;
using System.Data.Entity.Migrations;

namespace FantasyHockey.Data.Migrations
{
    public partial class ChangeSalaryToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Player", "Salary", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Player", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
