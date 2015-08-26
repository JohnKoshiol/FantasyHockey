using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using FantasyHockey.Data;
using FantasyHockey.Services.Team;
using FantasyHockey.Web.Models;

namespace FantasyHockey.Web.Controllers
{
    public class TeamController : Controller
    {
        private ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public ActionResult Index()
        {
            List<TeamViewModel> teams = new List<TeamViewModel>();
            teams = Mapper.Map<List<TeamViewModel>>(_teamService.GetAll());
            return View(teams);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "TeamId")] TeamViewModel team)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dbTeam = Mapper.Map<DbTeam>(team);
                    _teamService.CreateTeam(dbTeam);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(team);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = Mapper.Map<TeamViewModel>(_teamService.GetTeamById(id));

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(TeamViewModel team, string submit)
        {
            if (submit == "submit")
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var dbTeam = Mapper.Map<DbTeam>(team);
                        _teamService.UpdateTeam(dbTeam);

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
                    Delete(team);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(team);
        }

        public void Delete(TeamViewModel team)
        {
            var dbTeam = Mapper.Map<DbTeam>(team);
            _teamService.DeleteTeam(dbTeam);
        }
    }
}