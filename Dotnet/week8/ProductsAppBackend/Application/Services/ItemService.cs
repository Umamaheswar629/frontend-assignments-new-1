using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ItemService:IItemService

    // ItemService talks to DB through the repository interface
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET all — converts List<Item> → List<ItemDto>
        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var items = await _itemRepository.GetAllAsync();

            // Convert each Item entity → ItemDto
            return items.Select(item => new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Category = item.Category,
                Price = item.Price,
                Quantity = item.Quantity,
                Status = item.Status,
                Description = item.Description
            });
        }

        // GET by id — converts Item → ItemDto
        public async Task<ItemDto?> GetByIdAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id);

            // If item not found return null
            if (item == null) return null;

            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Category = item.Category,
                Price = item.Price,
                Quantity = item.Quantity,
                Status = item.Status,
                Description = item.Description
            };
        }

        // POST — converts CreateItemDto → Item → ItemDto
        public async Task<ItemDto> CreateAsync(CreateItemDto dto)
        {
            // Convert the DTO coming from Angular into a Domain entity
            var item = new Item
            {
                Name = dto.Name,
                Category = dto.Category,
                Price = dto.Price,
                Quantity = dto.Quantity,
                Status = dto.Status,
                Description = dto.Description
            };

            var created = await _itemRepository.CreateAsync(item);

            // Send back the created item as a DTO to Angular
            return new ItemDto
            {
                Id = created.Id,
                Name = created.Name,
                Category = created.Category,
                Price = created.Price,
                Quantity = created.Quantity,
                Status = created.Status,
                Description = created.Description
            };
        }

        // PUT — update existing item
        public async Task<ItemDto?> UpdateAsync(int id, CreateItemDto dto)
        {
            var item = new Item
            {
                Name = dto.Name,
                Category = dto.Category,
                Price = dto.Price,
                Quantity = dto.Quantity,
                Status = dto.Status,
                Description = dto.Description
            };

            var updated = await _itemRepository.UpdateAsync(id, item);

            if (updated == null) return null;

            return new ItemDto
            {
                Id = updated.Id,
                Name = updated.Name,
                Category = updated.Category,
                Price = updated.Price,
                Quantity = updated.Quantity,
                Status = updated.Status,
                Description = updated.Description
            };
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            return await _itemRepository.DeleteAsync(id);
        }
}
}
