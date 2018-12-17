using Reminder.Api.Dtos;

namespace Reminder.Api.Models
{
    public class Item
    {
        public int Id { get; private set; }
        public string Username { get; set; }
        public string Date { get; set; } // timestamp - js: Date.now()
        public string Description { get; set; }

        public Item() { }

        public Item(ItemDto dto)
        {
            this.Date = dto.Date;
            this.Description = dto.Description;
            this.Username = dto.Username;
        }

        public void Update(ItemDto dto)
        {
            if (dto.Date != null)
            {
                this.Date = dto.Date;
            }
            if (dto.Description != null)
            {
                this.Description = dto.Description;
            }
        }
    }
}