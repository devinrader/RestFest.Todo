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
        [Route("Users/{userid}/Items/Open", Name = "GetOpenItems")]
        public List<Item> GetOpenItems(int userid)
        {
            //var context = new TodoDataContext();

            //return context.Select();
            return null;
        }

    }
}
