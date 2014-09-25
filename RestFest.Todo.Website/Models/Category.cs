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
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public User Owner { get; set; }
    }
}