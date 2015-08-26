using System;
using System.Data.Entity.Migrations;
using FantasyHockey.Data.Enums;

namespace FantasyHockey.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FantasyHockeyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

		protected override void Seed(FantasyHockeyContext context)
		{
			//bootstrap the database with team and player data
			context.Teams.AddOrUpdate(
				t => t.Name,
				new DbTeam
				{
					TeamId = 1,
					Location = "Minnesota",
					Name = "Wild",
					Division = "Central",
					Conference = "Western",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 2,
					Location = "Chicago",
					Name = "Blackhawks",
					Division = "Central",
					Conference = "Western",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 3,
					Location = "St. Louis",
					Name = "Blues",
					Division = "Central",
					Conference = "Western",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 4,
					Location = "Winnipeg",
					Name = "Jets",
					Division = "Central",
					Conference = "Western",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 5,
					Location = "San Jose",
					Name = "Sharks",
					Division = "Pacific",
					Conference = "Western",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 6,
					Location = "Los Angeles",
					Name = "Kings",
					Division = "Pacific",
					Conference = "Western",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 7,
					Location = "Vancouver",
					Name = "Canucks",
					Division = "Pacific",
					Conference = "Western",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 8,
					Location = "Detroit",
					Name = "Red Wings",
					Division = "Atlantic",
					Conference = "Eastern",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				}, new DbTeam
				{
					TeamId = 9,
					Location = "Montreal",
					Name = "Canadiens",
					Division = "Atlantic",
					Conference = "Eastern",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 10,
					Location = "Boston",
					Name = "Bruins",
					Division = "Atlantic",
					Conference = "Eastern",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 11,
					Location = "Ottawa",
					Name = "Senators",
					Division = "Atlantic",
					Conference = "Eastern",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 12,
					Location = "Pittsburgh",
					Name = "Penguins",
					Division = "Metropolitan",
					Conference = "Eastern",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 13,
					Location = "Philadelphia",
					Name = "Flyers",
					Division = "Metropolitan",
					Conference = "Eastern",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 14,
					Location = "Washington",
					Name = "Capitals",
					Division = "Metropolitan",
					Conference = "Eastern",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbTeam
				{
					TeamId = 15,
					Location = "New York",
					Name = "Rangers",
					Division = "Metropolitan",
					Conference = "Eastern",
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				}
			);

			context.Players.AddOrUpdate(
				p => p.LastName,
				new DbPlayer
				{
					FirstName = "Zach",
					LastName = "Parise",
					Position = Position.LeftWing,
					Salary = 11000000,
					TeamId = 1,
                    GamesPlayed = 74,
					Goals = 33,
					Assists = 29,
					Points = 62,
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbPlayer
				{
					FirstName = "Patrick",
					LastName = "Kane",
					Position = Position.RightWing,
					Salary = 6500000,
					TeamId = 2,
                    GamesPlayed = 61,
					Goals = 27,
					Assists = 37,
					Points = 64,
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbPlayer
				{
					FirstName = "Sidney",
					LastName = "Crosby",
					Position = Position.Center,
					Salary = 12000000,
					TeamId = 12,
                    GamesPlayed = 77,
					Goals = 28,
					Assists = 56,
					Points = 84,
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbPlayer
				{
					FirstName = "Alexander",
					LastName = "Ovechkin",
					Position = Position.RightWing,
					Salary = 10000000,
					TeamId = 14,
                    GamesPlayed = 81,
					Goals = 53,
					Assists = 28,
					Points = 81,
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbPlayer
				{
					FirstName = "Carey",
					LastName = "Price",
					Position = Position.Goalie,
					Salary = 6750000,
					TeamId = 9,
                    GamesPlayed = 66,
					Wins = 44,
					Losses = 16,
					GoalsAgainstAverage = 1.96,
					SavePercentage = .933,
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbPlayer
				{
					FirstName = "Devan",
					LastName = "Dubnyk",
					Position = Position.Goalie,
					Salary = 800000,
					TeamId = 1,
                    GamesPlayed = 58,
					Wins = 36,
					Losses = 14,
					GoalsAgainstAverage = 2.25,
					SavePercentage = .926,
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbPlayer
				{
					FirstName = "Ryan",
					LastName = "Suter",
					Position = Position.LeftDefense,
					Salary = 11000000,
					TeamId = 1,
                    GamesPlayed = 77,
					Goals = 2,
					Assists = 36,
					Points = 38,
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbPlayer
				{
					FirstName = "Duncan",
					LastName = "Keith",
					Position = Position.LeftDefense,
					Salary = 7600000,
					TeamId = 2,
                    GamesPlayed = 80,
					Goals = 10,
					Assists = 35,
					Points = 45,
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbPlayer
				{
					FirstName = "Jonas",
					LastName = "Brodin",
					Position = Position.RightDefense,
					Salary = 832500,
					TeamId = 1,
                    GamesPlayed = 71,
					Goals = 3,
					Assists = 4,
					Points = 7,
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				},
				new DbPlayer
				{
					FirstName = "Drew",
					LastName = "Doughty",
					Position = Position.RightDefense,
					Salary = 6700000,
					TeamId = 6,
                    GamesPlayed = 82,
					Goals = 7,
					Assists = 39,
					Points = 46,
					Created = DateTime.UtcNow,
					CreatedBy = "System Admin"
				}
			);
		}
    }
}
