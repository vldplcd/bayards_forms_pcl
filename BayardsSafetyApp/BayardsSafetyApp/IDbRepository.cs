using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BayardsSafetyApp
{
    public interface IDbRepository : IDisposable
    {
        int InsertItem<T>(T item);
        int InsertItems<T>(List<T> items);
        int DeleteItem<T>(T model);
        T GetItem<T>(int id) where T : new();
        IEnumerable<T> GetItems<T>() where T : new();       
    }
}