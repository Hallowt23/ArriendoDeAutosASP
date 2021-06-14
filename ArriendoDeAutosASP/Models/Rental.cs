using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArriendoDeAutosASP.Models
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required, numbers only.")]
        [StringLength(50, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 15)]
        [Display(Name = "Rut")]
        public string Rut { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string Type{ get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(10, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 1)]
        [Display(Name = "")]
        public string HP { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Total")]
        public int Total { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Car Id")]
        public int CarId { get; set; }
        [ForeignKey("Id")]
        public Vehicle Vehicle { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Office Id")]
        public int OfficeId { get; set; }
        [ForeignKey("Id")]
        public Office Office { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Pick Up")]
        public DateTime PickUp { get; set; }



    }
}
