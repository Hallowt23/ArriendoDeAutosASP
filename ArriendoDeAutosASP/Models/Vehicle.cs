using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArriendoDeAutosASP.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 3)]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 2)]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 3)]
        [Display(Name = "Type")]
        public string Type{ get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(10, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 1)]
        [Display(Name = "Horsepower")]
        public string HP { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Price")]
        public int Price { get; set; }


        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Model Year")]
        public DateTime ModelYear { get; set; }



    }
}
