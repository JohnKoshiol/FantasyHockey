using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FantasyHockey.Data;
using FantasyHockey.Data.Enums;
using FantasyHockey.Services.Player;
using FantasyHockey.Web.Models;
using NSubstitute;
using NUnit.Framework;

namespace FantasyHockey.Tests.Services.Player
{
    [TestFixture]
    public class PlayerServiceTests
    {
        private IPlayerService sut;
        private FantasyHockeyContext _context;
        private int playerId = 1;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<FantasyHockeyContext>();

            var players = new List<DbPlayer>
            {
                new DbPlayer
                {
                    PlayerId = playerId,
                    FirstName = "John",
                    LastName = "Test"
                },
                new DbPlayer
                {
                    PlayerId = playerId + 1,
                    FirstName = "Matt",
                    LastName = "Test"
                }
            };

            SetupDbSet(players, x => _context.Players = x);
            sut = new PlayerService(_context);
        }

        #region helpers
        
        //Set up the mock for context.Players
        private void SetupDbSet<T>(List<T> data, Func<DbSet<T>, DbSet<T>> applyFunc) where T : class
        {
            var players = data.AsQueryable();

            var substituteSet = Substitute.For<DbSet<T>, IQueryable<T>>();
            ((IQueryable<T>)substituteSet).Provider.Returns(players.Provider);
            ((IQueryable<T>)substituteSet).Expression.Returns(players.Expression);
            ((IQueryable<T>)substituteSet).ElementType.Returns(players.ElementType);
            ((IQueryable<T>)substituteSet).GetEnumerator().Returns(players.GetEnumerator());

            applyFunc(substituteSet);
        }

        #endregion

        #region FindTests
        
        [Test]
        public void GetAll_ReturnsAllPlayers()
        {
            var players = sut.GetAll();

            Assert.That(players.Count(), Is.EqualTo(2));
        }
        
        [Test]
        public void GetPlayerById_MatchingPlayerIdReturnsCorrectPlayer()
        {
            var player = sut.GetPlayerById(playerId);
            
            Assert.That(player.FirstName, Is.EqualTo("John"));
        }

        [Test]
        public void GetPlayerById_NonMatchingPlayerId_ReturnsNull()
        {
            var player = sut.GetPlayerById(10);

            Assert.That(player, Is.Null);
        }

        #endregion

        #region UpdateTests
        
        [Test]
        public void UpdatePlayer_MatchingPlayerId_ReturnsPlayer_IsAbleToCallUpdatePlayer()
        {
            var playerToUpdate = _context.Players.FirstOrDefault(p => p.PlayerId == playerId);

            Assert.That(playerToUpdate, Is.Not.Null);
        }

        [Test]
        public void UpdatePlayer_NonMatchingPlayerId_ReturnsNull_IsNotAbleToCallUpdatePlayer()
        {
            var playerToUpdate = _context.Players.FirstOrDefault(p => p.PlayerId == playerId + 10);

            Assert.That(playerToUpdate, Is.Null);
        }

        #endregion

        #region DeleteTests
        
        [Test]
        public void DeletePlayer_MatchingPlayerId_ReturnsPlayer_IsAbleToCallDeletePlayer()
        {
            var playerToDelete = _context.Players.FirstOrDefault(p => p.PlayerId == playerId);

            Assert.That(playerToDelete, Is.Not.Null);
        }

        [Test]
        public void DeletePlayer_NonMatchingPlayerId_ReturnsNull_IsNotAbleToCallDeletePlayer()
        {
            var playerToDelete = _context.Players.FirstOrDefault(p => p.PlayerId == playerId + 10);

            Assert.That(playerToDelete, Is.Null);
        }

        #endregion

        #region LogicTests

        [Test]
        public void Points_AreCalculatedCorrectly()
        {
            var goals = 3;
            var assists = 7;
            var pointsCalculated = goals + assists;

            var player = new PlayerViewModel
            {
                Goals = goals,
                Assists = assists
            };

            Assert.That(player.Points, Is.EqualTo(pointsCalculated));
        }

        [Test]
        public void Record_IsCalculatedCorrectly()
        {
            var wins = 5;
            var losses = 1;
            var recordCalculated = string.Format("{0}-{1}", wins, losses);

            var player = new PlayerViewModel
            {
                Wins =  wins,
                Losses =  losses
            };

            Assert.That(player.Record, Is.EqualTo(recordCalculated));
        }

        [Test]
        public void PointsPerGame_ZeroPoints_ReturnsZero()
        {
            var goals = 0;
            var assists = 0;
            var games = 2;
            var expectedResult = 0;

            var player = new PlayerViewModel
            {
                Goals = goals,
                Assists = assists,
                GamesPlayed = games
            };

            Assert.That(player.PointsPerGame, Is.EqualTo(expectedResult));
        }

        [Test]
        public void PointsPerGame_ZeroGamesPlayed_ReturnsZero()
        {
            var goals = 2;
            var assists = 2;
            var games = 0;
            var expectedResult = 0;

            var player = new PlayerViewModel
            {
                Goals =  goals,
                Assists = assists,
                GamesPlayed = games
            };

            Assert.That(player.PointsPerGame, Is.EqualTo(expectedResult));
        }

        [Test]
        public void PointsPerGame_PointsAndGamesPlayed_CalculatesCorrectly()
        {
            var goals = 1;
            var assists = 1;
            var games = 2;
            var expectedResult = 1;

            var player = new PlayerViewModel
            {
                Goals = goals,
                Assists = assists,
                GamesPlayed = games
            };

            Assert.That(player.PointsPerGame, Is.EqualTo(expectedResult));
        }

        [Test]
        public void UpdatePlayer_MapFrom_WorksCorrectly()
        {
            var originalPlayerLastName = _context.Players.FirstOrDefault(p => p.PlayerId == playerId).LastName;
            var existingPlayer = _context.Players.FirstOrDefault(p => p.PlayerId == playerId);

            var updatedPlayer = new DbPlayer
            {
                PlayerId = playerId,
                FirstName = "John",
                LastName = "Prufung",
                Position = Position.Center,
                TeamId = 1,
                Status = Status.Available,
                Salary = 3000,
                GamesPlayed = 5,
                Goals = 5,
                Assists = 5,
                Points = 10,
                Wins = 0,
                Losses = 0,
                GoalsAgainstAverage = 0,
                SavePercentage = 0,
                LastModified = DateTime.UtcNow,
                LastModifiedBy = "System Admin"
            };

            existingPlayer.MapFrom(updatedPlayer);

            Assert.That(existingPlayer.FirstName, Is.EqualTo(updatedPlayer.FirstName));
            Assert.That(existingPlayer.LastName, Is.EqualTo(updatedPlayer.LastName));
            Assert.That(existingPlayer.Position, Is.EqualTo(updatedPlayer.Position));
            Assert.That(existingPlayer.TeamId, Is.EqualTo(updatedPlayer.TeamId));
            Assert.That(existingPlayer.Status, Is.EqualTo(updatedPlayer.Status));
            Assert.That(existingPlayer.Salary, Is.EqualTo(updatedPlayer.Salary));
            Assert.That(existingPlayer.GamesPlayed, Is.EqualTo(updatedPlayer.GamesPlayed));
            Assert.That(existingPlayer.Goals, Is.EqualTo(updatedPlayer.Goals));
            Assert.That(existingPlayer.Assists, Is.EqualTo(updatedPlayer.Assists));
            Assert.That(existingPlayer.Points, Is.EqualTo(updatedPlayer.Points));
            Assert.That(existingPlayer.Wins, Is.EqualTo(updatedPlayer.Wins));
            Assert.That(existingPlayer.Losses, Is.EqualTo(updatedPlayer.Losses));
            Assert.That(existingPlayer.GoalsAgainstAverage, Is.EqualTo(updatedPlayer.GoalsAgainstAverage));
            Assert.That(existingPlayer.SavePercentage, Is.EqualTo(updatedPlayer.SavePercentage));
            Assert.That(existingPlayer.LastModified, Is.EqualTo(updatedPlayer.LastModified));
            Assert.That(existingPlayer.LastModifiedBy, Is.EqualTo(updatedPlayer.LastModifiedBy));
            Assert.That(existingPlayer.LastName, Is.Not.EqualTo(originalPlayerLastName));
        }
        
        #endregion
    }
}
