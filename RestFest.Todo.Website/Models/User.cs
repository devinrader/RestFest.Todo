using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFest.Todo.Website.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public User Owner { get; set; }

    }
}