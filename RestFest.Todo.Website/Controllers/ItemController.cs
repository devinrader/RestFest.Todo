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
        public IHttpActionResult GetItems(int userid) 
        {
            return null;
        }

        [Route("Users/{userid}/Items/Open", Name = "GetOpenItems")]
        public IHttpActionResult GetOpenItems(int userid)
        {
            //var context = new TodoDataContext();

            //return context.Select();
            return null;
        }

        [Route("Users/{userid}/Items/Closed", Name = "GetClosedItems")]
        public IHttpActionResult GetClosedItems(int userid) { return null; }

        [Route("Users/{userid}/Items/{itemid}", Name="GetItem")]
        public IHttpActionResult GetItem(int userid, int itemid) { return null; }

        [Route("Users/{userid}/Items/{itemid}/Complete", Name = "MakeItemComplete")]
        public IHttpActionResult MakeItemComplete(int userid, int itemid) { return null; }

        [Route("Users/{userid}/Items/{itemid}/Incomplete", Name = "MakeItemIncomplete")]
        public IHttpActionResult MakeItemIncomplete(int userid, int itemid) { return null; }    
    }
}
