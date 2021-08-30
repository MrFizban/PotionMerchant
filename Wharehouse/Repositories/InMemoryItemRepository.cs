using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;
using Microsoft.AspNetCore.Razor.Hosting;

namespace Catalog.Reposotory{
    public class InMemoryItemRepository : IItemRepository
    {
        private readonly  List<Item>  items = new List<Item>(){
            new Item{id = Guid.NewGuid(),name = "postion", price = 20, CreateData = DateTimeOffset.UtcNow },
            new Item{id = Guid.NewGuid(),name = "sword", price = 100, CreateData = DateTimeOffset.UtcNow },
            new Item{id = Guid.NewGuid(),name = "shiedl", price = 42, CreateData = DateTimeOffset.UtcNow }
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(this.items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.Where(item => item.id == id).SingleOrDefault());
        }

        public async  Task CreateItemAsync(Item item)
        {
            this.items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            int index = this.items.FindIndex(item1 => item1.id == item.id);
            this.items[index] = item;
            await Task.CompletedTask; 
        }

        public async Task DeleteItemAsync(Guid id)
        {
            this.items.RemoveAt(this.items.FindIndex(item => item.id == id));
            await Task.CompletedTask;
        }
    }
} 