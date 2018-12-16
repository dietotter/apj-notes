using Microsoft.AspNetCore.Identity;
using Reminder.Api.Data;
using Reminder.Api.Dtos;
using Reminder.Api.Models;
using Reminder.Api.Utils;

namespace Reminder.Api.Service
{
    public class AuthService
    {
        private ReminderContext _context;
        private PasswordHasher<User> _passwordHasher;

        public AuthService() { }

        public AuthService(ReminderContext context)
        {
            this._context = context;
            this._passwordHasher = new PasswordHasher<User>();
        }

        public(User, Error) Login(UserDto dto)
        {
            User User = GetUser(dto);
            if (User == null)
            {
                return (null, new Error("Invalid username"));
            }

            if (VerifiedPassword(User, dto))
            {
                return (User, null);
            }

            return (null, new Error("Invalid password"));
        }

        public(User, Error) Register(UserDto dto)
        {
            if (GetUser(dto) != null)
            {
                return (null, new Error("Such username already exists"));
            }
            User User = new User(dto);
            User.Password = _passwordHasher.HashPassword(User, dto.Password);

            _context.Users.Add(User);
            _context.SaveChanges();

            return (User, null);
        }

        private bool VerifiedPassword(User User, UserDto dto)
        {
            return _passwordHasher.VerifyHashedPassword(User, User.Password, dto.Password) == PasswordVerificationResult.Success;
        }

        private User GetUser(UserDto dto)
        {
            return _context.Users.Find(dto.UserName);
        }
    }
}