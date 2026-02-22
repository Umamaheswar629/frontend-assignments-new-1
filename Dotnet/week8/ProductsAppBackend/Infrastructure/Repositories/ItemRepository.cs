using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ItemRepository: IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        // SELECT * FROM Items
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        // SELECT * FROM Items WHERE Id = id
        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        // INSERT INTO Items
        public async Task<Item> CreateAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        // UPDATE Items SET ... WHERE Id = id
        public async Task<Item?> UpdateAsync(int id, Item item)
        {
            var existing = await _context.Items.FindAsync(id);

            // If item not found return null — controller will return 404
            if (existing == null) return null;

            // Update each field with the new values from Angular
            existing.Name = item.Name;
            existing.Category = item.Category;
            existing.Price = item.Price;
            existing.Quantity = item.Quantity;
            existing.Status = item.Status;
            existing.Description = item.Description;

            await _context.SaveChangesAsync();
            return existing;
        }

        // DELETE FROM Items WHERE Id = id
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Items.FindAsync(id);

            if (existing == null) return false;

            _context.Items.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

