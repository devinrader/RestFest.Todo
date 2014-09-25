using RestFest.Todo.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestFest.Todo.Website.Controllers
{
    public class HomeController : ApiController
    {
        [Route("Categories")]
        public List<Category> Categories { get; private set; }
        [Route("Users")]
        public List<User> Users { get; private set; }
    }
}
