using PointW.ResourceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFest.Todo.Website.Models
{
    public class User : Resource
    {
        [NeverShow]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdate { get; private set; }
        public User Owner { get; set; }

        public List<Item> Items { get; set; }
    }
}