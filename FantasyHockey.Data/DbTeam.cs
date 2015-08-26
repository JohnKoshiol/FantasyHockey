using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyHockey.Data
{
    [Table("Team")]
    public class DbTeam : BaseEntity
    {
        [Key]
        public int TeamId { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Division { get; set; }
        public string Conference { get; set; }

        public IEnumerable<DbPlayer> Players { get; set; }
        public bool IsDeleted { get; set; }
    }
}
