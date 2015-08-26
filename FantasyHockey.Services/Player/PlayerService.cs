using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using FantasyHockey.Data;

namespace FantasyHockey.Services.Player
{
    public class PlayerService : IPlayerService
    {
        FantasyHockeyContext _context { get; set; }

        public PlayerService(FantasyHockeyContext context)
        {
            _context = context;
            _context.Players.Load();
        }

        public IEnumerable<DbPlayer> GetAll()
        {
            var players = _context.Players.Where(p => p.IsDeleted == false).OrderByDescending(p => p.Points).ThenByDescending(p => p.SavePercentage).ToList();
            return players;
        }

        public DbPlayer GetPlayerById(int id)
        {
            return _context.Players.FirstOrDefault(p => p.PlayerId == id);
        }

        public void CreatePlayer(DbPlayer player)
        {
            SetDateAndUserCreatedInfo(player);
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public void UpdatePlayer(DbPlayer updatedPlayer)
        {
            SetDateAndUserUpdatedInfo(updatedPlayer);
            var existingPlayer = _context.Players.FirstOrDefault(p => p.PlayerId == updatedPlayer.PlayerId);
            existingPlayer.MapFrom(updatedPlayer);

            _context.Players.AddOrUpdate(existingPlayer);
            _context.SaveChanges();
        }

        public void DeletePlayer(DbPlayer deletedPlayer)
        {
            var existingPlayer = _context.Players.FirstOrDefault(p => p.PlayerId == deletedPlayer.PlayerId);
            existingPlayer.IsDeleted = true;
            SetDateAndUserUpdatedInfo(existingPlayer);

            _context.Players.AddOrUpdate(existingPlayer);
            _context.SaveChanges();
        }

        private void SetDateAndUserCreatedInfo(DbPlayer player)
        {
            player.Created = DateTime.UtcNow;
            player.CreatedBy = "System Admin";
        }

        private void SetDateAndUserUpdatedInfo(DbPlayer player)
        {
            player.LastModified = DateTime.UtcNow;
            player.LastModifiedBy = "System Admin";
        }
    }
}
