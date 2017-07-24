using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Akasa.Mobile.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Akasa.Mobile.Services
{
    public abstract class BaseDataStore<T> : IDataStore<T>
        where T: BaseDto
    {
        private bool isInitialized;
        private List<T> items;

        protected abstract string _baseBath { get; }

        public async Task<bool> AddItemAsync(T item)
        {
            await InitializeAsync();

            var customerInserted = await new AkasaHttpClient().Post<T, T>(_baseBath, item);

            var success = customerInserted.Id > 0;

            if (success)
            {
                item.Id = customerInserted.Id;
                items.Add(item);
            }

            return success;
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            await InitializeAsync();

            var _item = items.FirstOrDefault(arg => arg.Id == item.Id);
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(T item)
        {
            await InitializeAsync();

            var _item = items.FirstOrDefault(arg => arg.Id == item.Id);
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(int id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            items = await new AkasaHttpClient().Get<List<T>>(_baseBath);
            //var _items = new List<Item>
            //{
            //	new Item { Id = Guid.NewGuid().ToString(), Text = "Buy some cat food", Description="The cats are hungry"},
            //	new Item { Id = Guid.NewGuid().ToString(), Text = "Learn F#", Description="Seems like a functional idea"},
            //	new Item { Id = Guid.NewGuid().ToString(), Text = "Learn to play guitar", Description="Noted"},
            //	new Item { Id = Guid.NewGuid().ToString(), Text = "Buy some new candles", Description="Pine and cranberry for that winter feel"},
            //	new Item { Id = Guid.NewGuid().ToString(), Text = "Complete holiday shopping", Description="Keep it a secret!"},
            //	new Item { Id = Guid.NewGuid().ToString(), Text = "Finish a todo list", Description="Done"},
            //};

            //foreach (Item item in _items)
            //{
            //	items.Add(item);
            //}

            isInitialized = true;
        }
    }
}
