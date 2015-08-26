using System.Collections.Generic;
using FantasyHockey.Data;

namespace FantasyHockey.Services.Player
{
    public interface IPlayerService
    {
        IEnumerable<DbPlayer> GetAll();
        DbPlayer GetPlayerById(int id);
        void CreatePlayer(DbPlayer player);
        void UpdatePlayer(DbPlayer player);
        void DeletePlayer(DbPlayer player);
    }
}
