using AutoMapper;
using FantasyHockey.Data;
using FantasyHockey.Data.Enums;
using FantasyHockey.Services.Player;
using FantasyHockey.Services.Team;
using FantasyHockey.Web.Controllers;
using FantasyHockey.Web.Models;
using NSubstitute;
using NUnit.Framework;

namespace FantasyHockey.Tests.Web.Controllers
{
    [TestFixture]
    public class PlayerControllerTests
    {
        private IPlayerService _playerService;
        private ITeamService _teamService;
        private PlayerController sut;

        [SetUp]
        public void SetUp()
        {
            _playerService = Substitute.For<IPlayerService>();
            _teamService = Substitute.For<ITeamService>();
            sut = new PlayerController(_playerService, _teamService);
            SetUpMappings();
        }

        #region helpers
        
        private void SetUpMappings()
        {
            Mapper.CreateMap<DbPlayer, PlayerViewModel>();
            Mapper.CreateMap<PlayerViewModel, DbPlayer>();
        }

        #endregion

        #region CreateTests
        
        [Test]
        public void Create_MissingFirstName_DoesNotCallCreatePlayer()
        {
            sut.ModelState.AddModelError("", "First Name is required");
            var viewModel = new PlayerViewModel();
            
            sut.Create(viewModel);

            _playerService.DidNotReceive().CreatePlayer(Arg.Any<DbPlayer>());
        }

        [Test]
        public void Create_MissingPosition_DoesNotCallCreatePlayer()
        {
            sut.ModelState.AddModelError("", "Position is required");
            var viewModel = new PlayerViewModel();

            sut.Create(viewModel);

            _playerService.DidNotReceive().CreatePlayer(Arg.Any<DbPlayer>());
        }

        [Test]
        public void Create_AllRequiredFieldsPresent_CallsCreatePlayer()
        {
            var viewModel = new PlayerViewModel
            {
                PlayerId = 1,
                FirstName = "John",
                LastName = "Test",
                Position = Position.LeftDefense,
                Salary = 1000,
                TeamId = 1,
                Status = Status.Available
            };

            sut.Create(viewModel);

            _playerService.Received(1).CreatePlayer(Arg.Any<DbPlayer>());
        }

        #endregion

        #region UpdateTests
        
        [Test]
        public void Update_FirstNameMissing_DoesNotCallUpdatePlayer()
        {
            sut.ModelState.AddModelError("", "First Name is required");
            var viewModel = new PlayerViewModel();

            sut.Edit(viewModel, "submit");

            _playerService.DidNotReceive().UpdatePlayer(Arg.Any<DbPlayer>());
        }

        [Test]
        public void Update_PositionMissing_DoesNotCallUpdatePlayer()
        {
            sut.ModelState.AddModelError("", "Position is required");
            var viewModel = new PlayerViewModel();

            sut.Edit(viewModel, "submit");

            _playerService.DidNotReceive().UpdatePlayer(Arg.Any<DbPlayer>());
        }

        [Test]
        public void Update_AllRequiredFieldsPresent_CallsUpdatePlayer()
        {
            var viewModel = new PlayerViewModel
            {
                PlayerId = 1,
                FirstName = "John",
                LastName = "Test",
                Position = Position.LeftDefense,
                Salary = 1000,
                TeamId = 1,
                Status = Status.Available
            };

            sut.Edit(viewModel, "submit");

            _playerService.Received(1).UpdatePlayer(Arg.Any<DbPlayer>());
        }

        #endregion

        #region DeleteTests

        [Test]
        public void Delete_NoErrors_CallsDeletePlayer()
        {
            var viewModel = new PlayerViewModel();

            sut.Edit(viewModel, "delete");

            _playerService.Received(1).DeletePlayer(Arg.Any<DbPlayer>());
        }

        #endregion
    }
}
