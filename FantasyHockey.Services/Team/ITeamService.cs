using System.Collections.Generic;
using FantasyHockey.Data;

namespace FantasyHockey.Services.Team
{
    public interface ITeamService
    {
        IEnumerable<DbTeam> GetAll();
        DbTeam GetTeamById(int? id);
        void CreateTeam(DbTeam team);
        void UpdateTeam(DbTeam team);
        void DeleteTeam(DbTeam team);
    }
}
