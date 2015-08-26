using System;
using System.Data.Entity.Migrations;

namespace FantasyHockey.Data.Migrations
{
    public partial class AddIsDeletedFlagToPlayerAndTeam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Team", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Team", "IsDeleted");
            DropColumn("dbo.Player", "IsDeleted");
        }
    }
}
