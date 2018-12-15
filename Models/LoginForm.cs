using System.ComponentModel.DataAnnotations;

namespace Reminder.Models
{
    public class LoginForm
    {
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string Username {get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }
    
}