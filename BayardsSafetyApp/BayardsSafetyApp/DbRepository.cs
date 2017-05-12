using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BayardsSafetyApp.Entities;
using SQLite;
using Xamarin.Forms;

namespace BayardsSafetyApp
{
    public class DbRepository : IDbRepository
    {
        static SQLiteAsyncConnection context;
        
        public DbRepository(string filename)
        {          
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            context = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTable<T>() where T : new()
        {
            await context.CreateTableAsync<T>();
        }
        public async Task<List<T>> GetItemsAsync<T>() where T : new()
        {
            return await context.Table<T>().ToListAsync();
        }
        public async Task<T> GetItemAsync<T>(int id) where T : new()
        {
            return await context.GetAsync<T>(id);
        }
        public async Task<int> DeleteItemAsync<T>(T item)
        {
            return await context.DeleteAsync(item);
        }
        public async Task<int> UpdateItemAsync<T>(T item)
        {
            return await context.UpdateAsync(item);
        }
        public async Task<int> InsertItemAsync<T>(T item)
        {
            if (context.InsertAsync(item).Result != 0)
                return await context.UpdateAsync(item);
            else
                return 0;
        }

        public async Task<int> InsertItemsAsync<T>(List<T> items)
        {
            if (context.InsertAllAsync(items).Result != 0)
                return await context.UpdateAllAsync(items);
            else
                return 0;
        }

        #region DisposeRegion
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    SQLiteAsyncConnection.ResetPool();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}