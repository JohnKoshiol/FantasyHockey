using System;
using System.Data.Entity.Migrations;

namespace FantasyHockey.Data.Migrations
{
    public partial class ThirdInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TeamId = c.Int(),
                        Goals = c.Int(),
                        Assists = c.Int(),
                        Points = c.Int(),
                        Wins = c.Int(),
                        Losses = c.Int(),
                        GoalsAgainstAverage = c.Double(),
                        SavePercentage = c.Double(),
                        GamesPlayed = c.Int(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastModified = c.DateTime(),
                        LastModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.PlayerId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Name = c.String(),
                        Division = c.String(),
                        Conference = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        LastModified = c.DateTime(),
                        LastModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Team");
            DropTable("dbo.Player");
        }
    }
}
