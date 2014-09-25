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
        [Route("Users/{userid}/Items", Name="GetItems")]
        public List<Item> GetItems(int userid) 
        {
            return null;
        }

        [Route("Users/{userid}/Items/Open", Name = "GetOpenItems")]
        public List<Item> GetOpenItems(int userid)
        {
            //var context = new TodoDataContext();

            //return context.Select();
            return null;
        }

        [Route("Users/{userid}/Items/Closed", Name = "GetClosedItems")]
        public List<Item> GetClosedItems(int userid) { return null; }

        [Route("Users/{userid}/Items/{itemid}", Name="GetItem")]
        public List<User> GetItem(int userid, int itemid) { return null; }

        [Route("Users/{userid}/Items/{itemid}/Complete", Name = "MakeItemComplete")]
        public List<User> MakeItemComplete(int userid, int itemid) { return null; }

        [Route("Users/{userid}/Items/{itemid}/Incomplete", Name = "MakeItemIncomplete")]
        public List<User> MakeItemIncomplete(int userid, int itemid) { return null; }    
    }
}
