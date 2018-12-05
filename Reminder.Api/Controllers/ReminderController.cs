using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Reminder.Api.Data;
using Reminder.Api.Dtos;
using Reminder.Api.Models;
using Reminder.Api.Service;

namespace Reminder.Api
{
    [Route("api/reminder")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private ItemService _itemService;
        public ReminderController(ReminderContext Context)
        {
            _itemService = new ItemService(Context);
        }

        [HttpGet]
        public ActionResult<ItemDto> GetAll()
        {
            List<Item> Items = _itemService.GetAll();
            return Ok(Items);
        }

        [Route("{id}"), HttpDelete]
        public ActionResult<ItemDto> Delete([FromRoute] int id)
        {
            Item Item = _itemService.Get(id);
            if (Item == null) return NotFound(id);

            _itemService.Delete(Item);

            return Ok();
        }

        [Route("{id}"), HttpPatch]
        public ActionResult<string> Update([FromRoute] int id, [FromBody] ItemDto dto)
        {
            Item Item = _itemService.Get(id);
            if (Item == null) return NotFound(id);

            _itemService.Update(Item, dto);

            return Ok(Item);
        }

        [HttpPost]
        public ActionResult<string> Create([FromBody] ItemDto dto)
        {
            Item Item = _itemService.Create(dto);

            return Ok(Item);
        }
    }
}