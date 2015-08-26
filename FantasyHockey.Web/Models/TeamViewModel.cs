using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FantasyHockey.Web.Models
{
    public class TeamViewModel : BaseViewModel
    {
        public TeamViewModel()
        {
           // Players = Enumerable.Empty<PlayerViewModel>();
        }

        public int TeamId { get; set; }
        
        [Required]
        [StringLength(20, ErrorMessage = "Location cannot exceed 20 characters")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Team Name")]
        [StringLength(20, ErrorMessage = "Team Name cannot exceed 20 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Division cannot exceed 20 characters")]
        public string Division { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Conference cannot exceed 20 characters")]
        public string Conference { get; set; }

        //public IEnumerable<PlayerViewModel> Players { get; set; }
        public bool IsDeleted { get; set; }
    }
}