using System.Data.Entity;

namespace FantasyHockey.Data
{
    public class FantasyHockeyContext : DbContext
    {
        public FantasyHockeyContext()
            : base("FantasyHockey")
        {
        }

        public virtual DbSet<DbPlayer> Players { get; set; }
        public virtual DbSet<DbTeam> Teams { get; set; }
    }
}
