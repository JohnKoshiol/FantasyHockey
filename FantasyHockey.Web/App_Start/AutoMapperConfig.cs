using AutoMapper;
using FantasyHockey.Data;
using FantasyHockey.Web.Models;

namespace FantasyHockey.Web
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<DbPlayer, PlayerViewModel>();
            Mapper.CreateMap<PlayerViewModel, DbPlayer>();
            Mapper.CreateMap<DbTeam, TeamViewModel>();
            Mapper.CreateMap<TeamViewModel, DbTeam>();
        }
    }
}