using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BayardsSafetyApp
{
    public interface IDbRepository : IDisposable
    {
        Task<int> InsertItemAsync<T>(T item);
        Task<int> InsertItemsAsync<T>(List<T> items);
        Task<int> UpdateItemAsync<T>(T item);
        Task<int> DeleteItemAsync<T>(T model);
        Task<T> GetItemAsync<T>(int id) where T : new();
        Task<List<T>> GetItemsAsync<T>() where T : new();
        Task CreateTable<T>() where T : new();
    }
}