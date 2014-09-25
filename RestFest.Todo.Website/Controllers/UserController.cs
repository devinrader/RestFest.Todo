using RestFest.Todo.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestFest.Todo.Website.Controllers
{
    public class UserController : ApiController
    {
        [Route("Users")]
        public List<User> Get()
        {
            return null;
        }

        [Route("Users/{userId}")]
        public User Get(int userId)
        {
            return null;
        }

        [Route("Users/")]
        public User Post(User category)
        {
            return null;
        }
    }
}
