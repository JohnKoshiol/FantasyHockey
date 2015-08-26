using AutoMapper;
using FantasyHockey.Data;
using FantasyHockey.Services.Team;
using FantasyHockey.Web.Controllers;
using FantasyHockey.Web.Models;
using NSubstitute;
using NUnit.Framework;

namespace FantasyHockey.Tests.Web.Controllers
{
    
    [TestFixture]
    public class TeamControllerTests
    {
        private TeamController sut;
        private ITeamService _teamService;
        private int TeamId = 1;

        [SetUp]
        public void SetUp()
        {
            _teamService = Substitute.For<ITeamService>();
            sut = new TeamController(_teamService);

            SetUpMappings();
        }

        #region Helpers

        private void SetUpMappings()
        {
            Mapper.CreateMap<DbTeam, TeamViewModel>();
            Mapper.CreateMap<TeamViewModel, DbTeam>();
        }

        #endregion

        #region CreateTests

        [Test]
        public void Create_MissingRequiredFieldLocation_DoesNotCallCreateTeam()
        {
            sut.ModelState.AddModelError("", "Location field is required");
            var viewModel = new TeamViewModel
            {
                TeamId = TeamId,
                Name = "Test",
                Division = "Western",
                Conference = "Madeup"
            };

            sut.Create(viewModel);

            _teamService.DidNotReceive().CreateTeam(Arg.Any<DbTeam>());
        }

        [Test]
        public void Create_AllRequiredFieldsPresent_CallsCreateTeam()
        {
            var viewModel = new TeamViewModel
            {
                TeamId = TeamId,
                Location = "Minnesota",
                Name = "Test",
                Division = "Western",
                Conference = "Madeup"
            };

            sut.Create(viewModel);

            _teamService.Received(1).CreateTeam(Arg.Any<DbTeam>());
        }

        #endregion

        #region UpdateTests

        [Test]
        public void Update_MissingRequiredFieldLocation_DoesNotCallUpdateTeam()
        {
            sut.ModelState.AddModelError("", "Location field is required");
            var viewModel = new TeamViewModel
            {
                TeamId = TeamId,
                Name = "Test",
                Division = "Western",
                Conference = "Madeup"
            };

            sut.Edit(viewModel, "submit");

            _teamService.DidNotReceive().UpdateTeam(Arg.Any<DbTeam>());
        }

        [Test]
        public void Update_AllRequiredFieldsPresent_CallsUpdateTeam()
        {
            var viewModel = new TeamViewModel
            {
                TeamId = TeamId,
                Location = "Minnesota",
                Name = "Test",
                Division = "Western",
                Conference = "Madeup"
            };

            sut.Edit(viewModel, "submit");

            _teamService.Received(1).UpdateTeam(Arg.Any<DbTeam>());
        }

        #endregion

        #region DeleteTests

        [Test]
        public void Delete_NoErrors_CallsDeleteTeam()
        {
            var viewModel = new TeamViewModel
            {
                TeamId = TeamId,
            };

            sut.Edit(viewModel, "delete");

            _teamService.Received(1).DeleteTeam(Arg.Any<DbTeam>());
        }

        #endregion
    }
}
