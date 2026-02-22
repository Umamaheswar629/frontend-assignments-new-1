using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item?> GetByIdAsync(int id);
        Task<Item> CreateAsync(Item item);
        Task<Item?> UpdateAsync(int id, Item item);
        Task<bool> DeleteAsync(int id);
    }
}
