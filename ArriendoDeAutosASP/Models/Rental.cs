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
        [Display(Name = "Client Id")]
        [ForeignKey("Client")]
        public int ClientId {get; set;}
        public virtual Client Client { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Vehicle Id")]
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Office Id")]
        [ForeignKey("Office")]
        public int OfficeId { get; set; }
        public virtual Office Office { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Days")]
        public int Days { get; set; }

        [StringLength(150, ErrorMessage = "Between {2} and {1} letters", MinimumLength = 0)]
        [Display(Name = "Note")]
        public string Note { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Pick Up")]
        public DateTime PickUp { get; set; }
    }
}
