using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//PODRIA TENER QUE BORRAR ESTO
namespace ArriendoDeAutosASP.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "From")]
        public String EmailFrom { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "To")]
        public String EmailTo { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Subject")]
        public String EmailSubject { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Body")]
        public String EmailBody { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date & Time")]
        public DateTime DateTime { get; set; }
    }
}
