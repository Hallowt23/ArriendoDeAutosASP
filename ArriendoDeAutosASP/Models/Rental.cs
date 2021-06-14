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

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Total")]
        public int Total { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Client Id")]
        public int ClientId { get; set; }
        [ForeignKey("Id")]
        public Client Client { get; set; }

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

        [StringLength(50, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 240)]
        [Display(Name = "Note")]
        public string Note { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Pick Up")]
        public DateTime PickUp { get; set; }
    }
}
