using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FantasyHockey.Data.Enums;

namespace FantasyHockey.Web.Models
{
    public class PlayerViewModel : BaseViewModel
    {
        public PlayerViewModel()
        {
            Teams = Enumerable.Empty<TeamViewModel>();
        }

        //player info
        public int PlayerId { get; set; }
        
        [Required]
        [Display(Name="First Name")]
        [StringLength(20, ErrorMessage = "First Name cannot exceed 20 characters")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name="Last Name")]
        [StringLength(20, ErrorMessage = "Last Name cannot exceed 20 characters")]
        public string LastName { get; set; }
        
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        
        [Required]
        public Position Position { get; set; }
        
        [Required]
        [Range(0, 999999999, ErrorMessage = "Salary cannot exceed 9 digits")]
        [RegularExpression(@"^\d{0,10}$", ErrorMessage = "Salary must be digits")]
        public double Salary { get; set; }

        [Required]
        [Display(Name="Team")]
        public int? TeamId { get; set; }
        public string FullTeamName { get; set; }

        //stats
        [Range(0, 999, ErrorMessage = "Goals cannot exceed 3 digits")]
        [RegularExpression(@"^\d{0,3}$", ErrorMessage = "Goals must be a digit")]
        public int? Goals { get; set; }

        [Range(0, 999, ErrorMessage = "Assists cannot exceed 3 digits")]
        [RegularExpression(@"^\d{0,3}$", ErrorMessage = "Assists must be a digit")]
        public int? Assists { get; set; }

        public int? Points
        {
            get
            {
                return (Goals + Assists);
            }
        }
        [Range(0, 999, ErrorMessage = "Wins cannot exceed 3 digits")]
        [RegularExpression(@"^\d{0,3}$", ErrorMessage = "Wins must be a digit")]
        public int? Wins { get; set; }

        [Range(0, 999, ErrorMessage = "Losses cannot exceed 3 digits")]
        [RegularExpression(@"^\d{0,3}$", ErrorMessage = "Losses must be a digit")]
        public int? Losses { get; set; }
        public string Record
        {
            get
            {
                if (Wins != null && Losses != null)
                {
                    return string.Format("{0}-{1}", Wins, Losses);
                }
                else
                {
                    return "0-0";
                }
            }
        }

        //  !!!! The "." may throw an error if the user enters 2.156 for example -> remove the reg ex?
        [Display(Name = "GAA")]
        [Range(0, 999, ErrorMessage = "Goals Against Average cannot exceed 3 digits")]
        [RegularExpression(@"^\d{0,3}$", ErrorMessage = "Goals Against Average must be a digit")]
        public double? GoalsAgainstAverage { get; set; }

        //  !!!! The "." may throw an error if the user enters 0.956 for example -> remove the reg ex?
        [Display(Name = "Save %")]
        [Range(0, 999, ErrorMessage = "Save Percentage cannot exceed 3 digits")]
        [RegularExpression(@"^\d{0,3}$", ErrorMessage = "Save Percentage must be a digit")]
        public double? SavePercentage { get; set; }

        [Display(Name = "Games Played")]
        [Range(0, 999, ErrorMessage = "Games Played cannot exceed 3 digits")]
        [RegularExpression(@"^\d{0,3}$", ErrorMessage = "Games Played must be a digit")]
        public int? GamesPlayed { get; set; }

        public double? PointsPerGame
        {
            get
            {
                if (Points != null && Points != 0 && GamesPlayed != null && GamesPlayed != 0)
                {
                    return (Points/GamesPlayed);
                }
                else
                {
                    return 0;
                }
            }
        }

        [Required]
        public Status Status { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<TeamViewModel> Teams { get; set; }
    }
}