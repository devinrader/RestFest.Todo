using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RestFest.Todo.Website.Models;
using PointW.ResourceModel;  

namespace RestFest.Todo.Website.Controllers
{
    public class ItemController : ApiController
    {
        private static List<Item> _items;

        public ItemController()
        {
            if (_items == null)
            {
                _items = new List<Item>
                {
                    new Item
                    {
                        Id = 1,
                        Title = "foo",
                        Text="Todo this"

                    },
                    new Item
                    {
                        Id = 2,
                        Title = "bar",
                        Text="Todo that"
                    },
                    new Item
                    {
                        Id = 3,
                        Title = "bleh",
                        Text="Todo stuff"
                    }
                };
            }

        }

        [Route("Users/{userid}/Items", Name="GetItems")]
        public IHttpActionResult GetItems(int userid) 
        {
            var items = _items.Where(i=>i.Owner.Id == userid);

            var usersResourceList = new SimpleResourceList<Item>();
            usersResourceList.Items = items.ToList();

            return Ok(items);            
        }

        [Route("Users/{userid}/Items/Open", Name = "GetOpenItems")]
        public IHttpActionResult GetOpenItems(int userid)
        {
            //TODO: Fix this query to only return open items
            var items = _items.Where(i => i.Owner.Id == userid && i.Status == "open");

            var usersResourceList = new SimpleResourceList<Item>();
            usersResourceList.Items = items.ToList();

            return Ok(items);
        }

        [Route("Users/{userid}/Items/Closed", Name = "GetClosedItems")]
        public IHttpActionResult GetClosedItems(int userid) 
        {
            //TODO: Fix this query to only return open items
            var items = _items.Where(i => i.Owner.Id == userid && i.Status == "close");

            var usersResourceList = new SimpleResourceList<Item>();
            usersResourceList.Items = items.ToList();

            return Ok(items);            
        }

        [Route("Users/{userid}/Items/{itemid}", Name="GetItem")]
        public IHttpActionResult GetItem(int userid, int itemid) {

            var item = _items.FirstOrDefault(i => i.Id == itemid);
            return Ok(item);
        }

        [Route("Users/{userid}/Items/{itemid}/Complete", Name = "MakeItemComplete")]
        public IHttpActionResult MakeItemComplete(int userid, int itemid) { return null; }

        [Route("Users/{userid}/Items/{itemid}/Incomplete", Name = "MakeItemIncomplete")]
        public IHttpActionResult MakeItemIncomplete(int userid, int itemid) { return null; }    
    }
}
