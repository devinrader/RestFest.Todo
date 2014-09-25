using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RestFest.Todo.Website.Models;  

namespace RestFest.Todo.Website.Controllers
{
    public class ItemController : ApiController
    {
        [Route("Items")]
        public List<Item> Get()
        {
            return null;
        }

        [Route("Items/{itemId}")]
        public Item Get(int itemId)
        {
            return null;
        }

        [Route("Items")]
        public Item Post(Item item)
        {
            return null;
        }
    }
}
