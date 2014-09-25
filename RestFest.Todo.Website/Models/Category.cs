using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFest.Todo.Website.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; }
        public DateTime DateUpdate { get; }
        public User Owner { get; set; }

    }
}