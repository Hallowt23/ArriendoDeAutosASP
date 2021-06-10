using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArriendoDeAutosASP.Models
{
    public class Office
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 4)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 3)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 8)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "PhoneNumber")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 5)]
        [Display(Name = "Mannager")]
        public string Mannager { get; set; }
    }
}
