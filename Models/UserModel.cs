using System.ComponentModel.DataAnnotations;

namespace Reminder.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Username is requisred")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}