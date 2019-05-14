using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoplusTest2.Models;
using Xamarin.Forms;

namespace InfoplusTest2.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Diary 2019",
                    Description ="Diary 2019 description #1",
                    CodeString = "4003273201309",
                    PictureURL = "https://drive.google.com/uc?export=download&id=1DAhIKwmyk5fTJRJa8FYdRBj59qolG4q1" },
                new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Evkazolin",
                    Description ="Nose spray description #2",
                    CodeString = "4823002210927",
                    PictureURL = "https://drive.google.com/uc?export=download&id=1N5HZeLljpbe7xWrTT5HehxvNDjC0ywWM"},
                new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Red pepper",
                    Description ="Red pepper description #3",
                    CodeString = "4820039290038",
                    PictureURL = "https://drive.google.com/uc?export=download&id=1DHv7fKPPt3rpyn8gCNiEWvUGYTX6IlLp" },
                new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Chest collection",
                    Description ="Chest collection description #4",
                    CodeString = "4823012800545",
                    PictureURL = "https://drive.google.com/uc?export=download&id=13b_vKnhvYCAmng15ZXQ4K3mA0DqqQp6X"},
                new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Chamomile",
                    Description ="Chamomile description #5",
                    CodeString = "4820085402584",
                    PictureURL = "https://drive.google.com/uc?export=download&id=1U5WY0rzT1OjmEb8KRndmYWAf1yo0ca_E" },
                new Item { Id = Guid.NewGuid().ToString(),
                    Text = "Dog rose",
                    Description ="Dog rose description #6",
                    CodeString = "4823012802662",
                    PictureURL = "https://drive.google.com/uc?export=download&id=14rQskBiwmCt7ksHffB2c341C_dAsZBsx" }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}