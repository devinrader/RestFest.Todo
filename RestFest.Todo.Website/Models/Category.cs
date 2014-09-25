using PointW.ResourceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFest.Todo.Website.Models
{
    public class Category : Resource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdate { get; private set; }

        public User Owner { get; set; }
    }
}