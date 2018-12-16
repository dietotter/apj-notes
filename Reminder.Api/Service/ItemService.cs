using System;
using System.Collections.Generic;
using System.Linq;
using Reminder.Api.Data;
using Reminder.Api.Dtos;
using Reminder.Api.Models;

namespace Reminder.Api.Service
{
    public class ItemService
    {
        private ReminderContext _context;

        public ItemService() { }

        public ItemService(ReminderContext context)
        {
            this._context = context;
        }

        public Item Get(int Id)
        {
            return _context.Items.Find(Id);
        }

        public List<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public void Delete(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public Item Create(ItemDto dto)
        {
            Item Item = _context.Items.Add(new Item(dto)).Entity;

            _context.SaveChanges();
            return Item;
        }

        public void Update(Item item, ItemDto dto)
        {
            item.Update(dto);

            _context.SaveChanges();
        }
    }
}