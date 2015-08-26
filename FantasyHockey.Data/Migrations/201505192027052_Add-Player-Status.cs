using System;
using System.Data.Entity.Migrations;

namespace FantasyHockey.Data.Migrations
{
    public partial class AddPlayerStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "Status");
        }
    }
}
