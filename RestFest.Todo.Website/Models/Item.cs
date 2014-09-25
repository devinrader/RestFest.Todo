using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFest.Todo.Website.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DueDate { get; set; }
        public Category Category { get; set; }
        public User Owner { get; set; }
        public User AssignedTo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}