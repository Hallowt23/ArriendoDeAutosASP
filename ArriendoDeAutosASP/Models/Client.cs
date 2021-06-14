using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArriendoDeAutosASP.Models
{
    public class Client
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
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(10, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 5)]
        [Display(Name = "Liscense")]
        public string Liscense { get; set; }

        [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name = "BirthDay")]
        public DateTime BirthDay { get; set; }
    }
}
