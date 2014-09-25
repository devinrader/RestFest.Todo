using PointW.ResourceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFest.Todo.Website.Models
{
    public class Item : Resource
    {
        [NeverShow]
        public int Id { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DueDate { get; set; }
        public Category Category { get; set; }
        public User Owner { get; set; }
        public User AssignedTo { get; set; }
        public bool IsComplete { get; set; }

        public string Status { get; set; }

        public DateTime? DateCreated { get; private set; }
        public DateTime? DateUpdate { get; private set; }
    }
}