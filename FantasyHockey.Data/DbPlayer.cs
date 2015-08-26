using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FantasyHockey.Data.Enums;

namespace FantasyHockey.Data
{
    [Table("Player")]
    public class DbPlayer : BaseEntity
    {
        [Key]
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }
        public double Salary { get; set; }
        public int? TeamId { get; set; }

        public int? Goals { get; set; }
        public int? Assists { get; set; }
        private int? _points;
        public int? Points
        {
            get
            {
                return _points;
            }

            set
            {
                _points = Goals + Assists;
            }
        }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public double? GoalsAgainstAverage { get; set; }
        public double? SavePercentage { get; set; }
        public int? GamesPlayed { get; set; }

        public Status Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
