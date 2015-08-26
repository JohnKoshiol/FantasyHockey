using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using FantasyHockey.Data;
using FantasyHockey.Services.Player;
using FantasyHockey.Services.Team;
using FantasyHockey.Web.Models;

namespace FantasyHockey.Web.Controllers
{
    public class PlayerController : Controller
    {
        private IPlayerService _playerService;
        private ITeamService _teamService;

        public PlayerController(IPlayerService playerService, ITeamService teamService)
        {
            _playerService = playerService;
            _teamService = teamService;
        }

        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<PlayerViewModel>>(_playerService.GetAll());
            foreach (var player in viewModel)
            {
                if (player.TeamId != null)
                {
                    var team = _teamService.GetTeamById(player.TeamId);
                    player.FullTeamName = team.Location + " " + team.Name;
                }
                else
                {
                    player.FullTeamName = "";
                }
            }

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new PlayerViewModel
            {
                Teams = GetTeams()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(PlayerViewModel player)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dbPlayer = Mapper.Map<DbPlayer>(player);
                    _playerService.CreatePlayer(dbPlayer);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            player.Teams = GetTeams();
            return View(player);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = Mapper.Map<PlayerViewModel>(_playerService.GetPlayerById(id));
            viewModel.Teams = GetTeams();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(PlayerViewModel player, string submit)
        {
            if (submit == "submit")
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var dbPlayer = Mapper.Map<DbPlayer>(player);
                        _playerService.UpdatePlayer(dbPlayer);

                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    Delete(player);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            player.Teams = GetTeams();
            return View(player);
        }

        public void Delete(PlayerViewModel player)
        {
            var dbPlayer = Mapper.Map<DbPlayer>(player);
            _playerService.DeletePlayer(dbPlayer);
        }

        private IEnumerable<TeamViewModel> GetTeams()
        {
            return Mapper.Map<IEnumerable<TeamViewModel>>(_teamService.GetAll());
        }
    }
}
