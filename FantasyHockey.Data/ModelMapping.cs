namespace FantasyHockey.Data
{
    public static class ModelMapping
    {
        public static void MapFrom(this DbPlayer existingPlayer, DbPlayer updatedPlayer)
        {
            existingPlayer.FirstName = updatedPlayer.FirstName;
            existingPlayer.LastName = updatedPlayer.LastName;
            existingPlayer.Position = updatedPlayer.Position;
            existingPlayer.TeamId = updatedPlayer.TeamId;
            existingPlayer.Status = updatedPlayer.Status;
            existingPlayer.Salary = updatedPlayer.Salary;
            existingPlayer.GamesPlayed = updatedPlayer.GamesPlayed;
            existingPlayer.Goals = updatedPlayer.Goals;
            existingPlayer.Assists = updatedPlayer.Assists;
            existingPlayer.Points = updatedPlayer.Points;
            existingPlayer.Wins = updatedPlayer.Wins;
            existingPlayer.Losses = updatedPlayer.Losses;
            existingPlayer.GoalsAgainstAverage = updatedPlayer.GoalsAgainstAverage;
            existingPlayer.SavePercentage = updatedPlayer.SavePercentage;
            existingPlayer.LastModified = updatedPlayer.LastModified;
            existingPlayer.LastModifiedBy = updatedPlayer.LastModifiedBy;
        }

        public static void MapFrom(this DbTeam existingTeam, DbTeam updatedTeam)
        {
            existingTeam.Location = updatedTeam.Location;
            existingTeam.Name = updatedTeam.Name;
            existingTeam.Division = updatedTeam.Division;
            existingTeam.Conference = updatedTeam.Conference;
            existingTeam.LastModified = updatedTeam.LastModified;
            existingTeam.LastModifiedBy = updatedTeam.LastModifiedBy;
        }
    }
}
