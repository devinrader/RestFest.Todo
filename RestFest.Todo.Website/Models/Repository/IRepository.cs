using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFest.Todo.Website.Models
{
    public interface IRepository<T>
    {
        IEnumerable<T> Select();
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Delete(int ID);
        void Update(T entity);
        void Save();        
    }
}