using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArriendoDeAutosASP.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "RentId")]
        [ForeignKey("Rental")]
        public int RentId { get; set; }
        public virtual Rental Rental { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Iva")]
        public int Iva { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Total")]
        public int Total { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Active")]
        public String Active { get; set; }
    }
}
