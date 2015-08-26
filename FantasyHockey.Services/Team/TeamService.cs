using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using FantasyHockey.Data;

namespace FantasyHockey.Services.Team
{
    public class TeamService : ITeamService
    {
        private FantasyHockeyContext _context;

        public TeamService(FantasyHockeyContext context)
        {
            _context = context;
            _context.Teams.Load();
        }

        public IEnumerable<DbTeam> GetAll()
        {
            List<DbTeam> teams = _context.Teams.Where(t => t.IsDeleted == false).ToList();
            return teams;
        }

        public DbTeam GetTeamById(int? id)
        {
            return _context.Teams.FirstOrDefault(t => t.TeamId == id);
        }

        public void CreateTeam(DbTeam team)
        {
            SetDateAndUserCreatedInfo(team);
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void UpdateTeam(DbTeam updatedTeam)
        {
            SetDateAndUserUpdatedInfo(updatedTeam);
            var existingTeam = _context.Teams.FirstOrDefault(t => t.TeamId == updatedTeam.TeamId);
            existingTeam.MapFrom(updatedTeam);

            _context.Teams.AddOrUpdate(existingTeam);
            _context.SaveChanges();
        }

        public void DeleteTeam(DbTeam deletedTeam)
        {
            var existingTeam = _context.Teams.FirstOrDefault(t => t.TeamId == deletedTeam.TeamId);
            existingTeam.IsDeleted = true;
            SetDateAndUserUpdatedInfo(existingTeam);

            _context.Teams.AddOrUpdate(existingTeam);
            _context.SaveChanges();
        }

        private void SetDateAndUserCreatedInfo(DbTeam team)
        {
            team.Created = DateTime.UtcNow;
            team.CreatedBy = "System Admin";
        }

        private void SetDateAndUserUpdatedInfo(DbTeam team)
        {
            team.LastModified = DateTime.UtcNow;
            team.LastModifiedBy = "System Admin";
        }
    }
}
