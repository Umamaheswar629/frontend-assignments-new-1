using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();
        Task<ItemDto?> GetByIdAsync(int id);
        Task<ItemDto> CreateAsync(CreateItemDto dto);
        Task<ItemDto?> UpdateAsync(int id, CreateItemDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
