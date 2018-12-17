using System.ComponentModel.DataAnnotations;
using Reminder.Api.Dtos;

namespace Reminder.Api.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public User() { }

        public User(UserDto dto)
        {
            this.Username = dto.Username;
            this.Password = dto.Password;
            this.Name = dto.Name;
        }

        public UserDto ToDto()
        {
            return new UserDto
            {
                Username = this.Username,
                    Name = this.Name,
            };
        }
    }
}