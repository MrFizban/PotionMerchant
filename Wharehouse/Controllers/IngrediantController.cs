using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog;
using Catalog.Dto;
using Catalog.Entities;
using Catalog.Reposotory;
using Microsoft.AspNetCore.Mvc;
using PotionMerchant.Entity;
using PotionMerchant.Repository;

namespace PotionMerchant.Controllers
{
    [ApiController]
    [Route("ingrediant")]
    public class IngrediantController : ControllerBase
    {
         private readonly IIngrediantRepository repo;

        public IngrediantController(IIngrediantRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<IngrediantDto>> GetItemsAsyncv()
        {
            return (await this.repo.GetIngrediantsAsync())
                .Select(item => item.AsDto() );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemAsync(Guid id)
        {
            var item = await this.repo.GetIngrediantAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item.AsDto());
        }

        
        [HttpPost]
        public async Task<ActionResult<IngrediantDto>> CreateIngrediantAsync(CreateIngediantDto createIngrediantDto)
        {
            Ingrediant ingrediant = new()
            {
                id = Guid.NewGuid(),
                name = createIngrediantDto.name,
                effetti = createIngrediantDto.effetti,
                descriptionShort = createIngrediantDto.descriptionShort,
                descriptionLong = createIngrediantDto.descriptionLong,
                price = createIngrediantDto.price,
                weight = createIngrediantDto.weight,
                size = createIngrediantDto.size
            };

            await this.repo.CreateIngrediantAsync(ingrediant);

            
            // ReSharper disable once Mvc.ActionNotResolved
            return CreatedAtAction(nameof(this.GetItemAsync), new { id = ingrediant.id }, ingrediant.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(Guid id, UpdateIngradiantDto updateIngradiantDto)
        {
            Ingrediant exixtingIgrediant = await this.repo.GetIngrediantAsync(id);

            if (exixtingIgrediant is null)
            {
                return NotFound();
            }
            
            Ingrediant updatedIngrediant = exixtingIgrediant with {
                name = updateIngradiantDto.name,
                effetti = updateIngradiantDto.effetti,
                descriptionShort = updateIngradiantDto.descriptionShort,
                descriptionLong = updateIngradiantDto.descriptionLong,
                price = updateIngradiantDto.price,
                weight = updateIngradiantDto.weight,
                size = updateIngradiantDto.size
            };
            
            await this.repo.UpdateIngrediantAsync(updatedIngrediant);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            if (this.repo.GetIngrediantAsync(id) is null)
            {
                return NotFound();
            }
            
            await this.repo.DeleteIngrediantAsync(id);

            return NoContent();
        }


       
    }
}