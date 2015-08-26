using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FantasyHockey.Data;
using FantasyHockey.Services.Team;
using NSubstitute;
using NUnit.Framework;

namespace FantasyHockey.Tests.Services.Team
{
    [TestFixture]
    public class TeamServiceTests
    {
        private ITeamService sut;
        private FantasyHockeyContext _context;
        private int TeamId = 1;
           
        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<FantasyHockeyContext>();

            var teams = new List<DbTeam>
            {
                new DbTeam
                {
                    TeamId = TeamId,
                    Location = "Test",
                    Name = "Hawks"
                },
                new DbTeam
                {
                    TeamId = TeamId + 1,
                    Location = "Test",
                    Name = "Blaze"                    
                }
            };

            SetUpDbSet(teams, x => _context.Teams = x);
            sut = new TeamService(_context);
        }

        #region Helpers

        //Set up the mock for context.Teams
        private void SetUpDbSet<T>(List<T> data, Func<DbSet<T>, DbSet<T>> applyFunc) where T : class
        {
            var teams = data.AsQueryable();

            var substituteSet = Substitute.For<DbSet<T>, IQueryable<T>>();
            ((IQueryable<T>)substituteSet).Provider.Returns(teams.Provider);
            ((IQueryable<T>)substituteSet).Expression.Returns(teams.Expression);
            ((IQueryable<T>)substituteSet).ElementType.Returns(teams.ElementType);
            ((IQueryable<T>)substituteSet).GetEnumerator().Returns(teams.GetEnumerator());

            applyFunc(substituteSet);
        }

        #endregion

        #region FindTests

        [Test]
        public void GetAll_ReturnsAllActiveTeams()
        {
            var teams = sut.GetAll();

            Assert.That(teams.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetTeamById_MatchingTeamId_ReturnsCorrectTeam()
        {
            var team = sut.GetTeamById(TeamId);

            Assert.That(team, Is.Not.Null);
            Assert.That(team.Name, Is.EqualTo("Hawks"));
        }

        [Test]
        public void GetTeamById_NonMatchingTeamId_ReturnsNull()
        {
            var team = sut.GetTeamById(TeamId + 10);

            Assert.That(team, Is.Null);
        }

        #endregion

        #region UpdateTests

        [Test]
        public void UpdateTeam_MatchingTeamId_ReturnsTeam_IsAbleToCallUpdateTeam()
        {
            var teamToUpdate = _context.Teams.FirstOrDefault(t => t.TeamId == TeamId);

            Assert.That(teamToUpdate, Is.Not.Null);
        }

        [Test]
        public void UpdateTeam_NonMatchingTeamId_ReturnsNull_IsNotAbleToCallUpdateTeam()
        {
            var teamToUpdate = _context.Teams.FirstOrDefault(t => t.TeamId == (TeamId + 10));

            Assert.That(teamToUpdate, Is.Null);
        }

        #endregion

        #region DeleteTests

        [Test]
        public void DeleteTeam_MatchingTeamId_ReturnsTeam_IsAbleToCallDeletePlayer()
        {
            var teamToDelete = _context.Teams.FirstOrDefault(t => t.TeamId == TeamId);

            Assert.That(teamToDelete, Is.Not.Null);
        }

        [Test]
        public void DeleteTeam_NonMatchingTeamId_ReturnsNull_IsNotAbleToCallDeleteTeam()
        {
            var teamToDelete = _context.Teams.FirstOrDefault(t => t.TeamId == (TeamId + 10));

            Assert.That(teamToDelete, Is.Null);
        }

        #endregion

        #region LogicTests

        [Test]
        public void UpdateTeam_MapFrom_WorksCorrectly()
        {
            var originalTeamName = _context.Teams.FirstOrDefault(t => t.TeamId == TeamId).Name;
            var existingTeam = _context.Teams.FirstOrDefault(t => t.TeamId == TeamId);

            var updatedTeam = new DbTeam
            {
                TeamId = TeamId,
                Location = "Minneapolis",
                Name = "Lakers",
                Division = "Northern",
                Conference = "Awesome",
                LastModified = DateTime.UtcNow,
                LastModifiedBy = "System Admin"
            };

            existingTeam.MapFrom(updatedTeam);

            Assert.That(existingTeam.Location, Is.EqualTo(updatedTeam.Location));
            Assert.That(existingTeam.Name, Is.EqualTo(updatedTeam.Name));
            Assert.That(existingTeam.Division, Is.EqualTo(updatedTeam.Division));
            Assert.That(existingTeam.Conference, Is.EqualTo(updatedTeam.Conference));
            Assert.That(existingTeam.LastModified, Is.EqualTo(updatedTeam.LastModified));
            Assert.That(existingTeam.LastModifiedBy, Is.EqualTo(updatedTeam.LastModifiedBy));
            Assert.That(existingTeam.Name, Is.Not.EqualTo(originalTeamName));
        }

        #endregion
    }
}
