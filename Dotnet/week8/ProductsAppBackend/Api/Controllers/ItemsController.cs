using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]   // ← all endpoints need valid JWT token
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/Items — All roles
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Viewer")]
        public async Task<IActionResult> GetItems()
        {
            var items = await _itemService.GetAllAsync();
            return Ok(items);
        }

        // GET: api/Items/5 — All roles
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,Viewer")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null)
                return NotFound($"Item with ID {id} not found.");
            return Ok(item);
        }

        // POST: api/Items — Admin and Manager only
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> PostItem([FromBody] CreateItemDto dto)
        {
            var created = await _itemService.CreateAsync(dto);
            return CreatedAtAction("GetItem", new { id = created.Id }, created);
        }

        // PUT: api/Items/5 — Admin and Manager only
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> PutItem(int id, [FromBody] CreateItemDto dto)
        {
            var updated = await _itemService.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound($"Item with ID {id} not found.");
            return Ok(updated);
        }

        // DELETE: api/Items/5 — Admin only
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var deleted = await _itemService.DeleteAsync(id);
            if (!deleted)
                return NotFound($"Item with ID {id} not found.");
            return NoContent();
        }
    }
}
