using System.ComponentModel.DataAnnotations;  
  
namespace Reminder.Models  
{  
    public class UserModel  
    {  
        [Required(ErrorMessage = "UserName is requisred")]  
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }  
} 