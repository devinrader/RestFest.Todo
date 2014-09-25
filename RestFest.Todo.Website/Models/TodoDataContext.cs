using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestFest.Todo.Website.Models
{
    public class TodoDataContext : DbContext
    {
        static TodoDataContext _current;

        private TodoDataContext()
        {
           
        }

        public static TodoDataContext Current()
        {
            if (_current == null)
            {
                _current = new TodoDataContext();

                _current.Items.Add(new Item());
                _current.Items.Add(new Item());
                _current.Items.Add(new Item());
                _current.Items.Add(new Item());

                _current.Users.Add(new User());
                _current.Users.Add(new User());
                _current.Users.Add(new User());
                _current.Users.Add(new User());

                _current.Categories.Add(new Category());
                _current.Categories.Add(new Category());
                _current.Categories.Add(new Category());
                _current.Categories.Add(new Category());
            }

            return _current;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        
    }
}