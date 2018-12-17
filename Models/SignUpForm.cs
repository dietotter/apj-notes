using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Reminder.Models
{
    public class SignUpForm
    {   
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }
    }
}
