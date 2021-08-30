using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog;
using Catalog.Dto;
using Catalog.Entities;
using Catalog.Reposotory;
using Microsoft.AspNetCore.Mvc;

namespace DefaultNamespace
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository repo;

        public ItemController(IItemRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsyncv()
        {
            return (await this.repo.GetItemsAsync())
                .Select(item => item.AsDto() );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemAsync(Guid id)
        {
            var item = await this.repo.GetItemAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }

        
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto createItemDto)
        {
            Item item = new()
            {
                id = Guid.NewGuid(),
                name = createItemDto.name,
                price = createItemDto.price,
                CreateData = DateTimeOffset.UtcNow
            };

            await this.repo.CreateItemAsync(item);

            
            // ReSharper disable once Mvc.ActionNotResolved
            return CreatedAtAction(nameof(this.GetItemAsync), new { id = item.id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(Guid id, UpdateItemDto updateItemDto)
        {
            Item exixtingItem = await this.repo.GetItemAsync(id);

            if (exixtingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = exixtingItem with
            {
                name = updateItemDto.name,
                price = updateItemDto.price
            };

            await this.repo.UpdateItemAsync(updatedItem);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            if (this.repo.GetItemAsync(id) is null)
            {
                return NotFound();
            }
            
            await this.repo.DeleteItemAsync(id);

            return NoContent();
        }


       
    }
}