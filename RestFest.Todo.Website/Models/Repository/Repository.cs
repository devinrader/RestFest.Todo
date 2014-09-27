using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFest.Todo.Website.Models
{
    //TODO: Make an IQueryable so you don't need to always call Select() to get data

    public class Repository<T> : IRepository<T>
    {
        private static IRepository<T> _instance;
        private IList<T> _entities;


        public static IRepository<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Repository<T>();
                }

                return _instance;
            }        
        }

        private Repository()
        {
            _entities = new List<T>();
        }

        public IEnumerable<T> Select()
        {
            return _entities;
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities) {
            foreach (T e in entities) { _entities.Add(e); }
        }

        public virtual void Delete(int ID)
        {
        }

        public virtual void Update(T entity)
        {
        }

        public virtual void Save()
        {
        }
    }
}