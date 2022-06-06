using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id
        {
            get; set;
        }

        [Required(ErrorMessage = "A cinema logo is required.")]
        [Display(Name = "Cinema Logo")]
        public string Logo
        {
            get; set;
        }

        [Required(ErrorMessage = "A cinema name is required.")]
        [MinLength(3, ErrorMessage = "The name must be at least 3 characters")]
        [Display(Name = "Cinema Name")]
        public string Name
        {
            get; set;
        }

        [Required(ErrorMessage = "A cinema description is required.")]
        [MinLength(3, ErrorMessage = "The description must be at least 3 characters")]
        [Display(Name = "Description")]
        public string Description
        {
            get; set;
        }

        // relationships

        public List<Movie> Movies
        {
            get; set;
        }
    }
}
