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

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "First name")]
        [DataType(DataType.Text)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [DataType(DataType.Text)]
        [Required]
        public string LastName { get; set; }
    }
}
