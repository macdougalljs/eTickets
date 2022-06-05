using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer: IEntityBase
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "A profile picture is required.")]
        public string ProfilePictureURL
        {
            get; set;
        }

        [Required(ErrorMessage = "A full name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name needs to be at least 3-50 characters")]
        [Display(Name = "Full Name")]
        public string FullName
        {
            get; set;
        }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "A biography is required.")]
        public string Bio
        {
            get; set;
        }


        //Relationships

        public List<Movie> Movies
        {
            get; set;
        }
    }
}
