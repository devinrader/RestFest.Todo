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
                        Text="Todo this",
                        Owner=UserController._users[0],
                        Status = "open"

                    },
                    new Item
                    {
                        Id = 2,
                        Title = "bar",
                        Text="Todo that",
                        Owner=UserController._users[0],
                        Status = "closed"
                    },
                    new Item
                    {
                        Id = 3,
                        Title = "bleh",
                        Text="Todo stuff",
                        Owner=UserController._users[1],
                        Status="open"
                    }
                };

                foreach (var i in _items)
                {
                    i.Relations.Add("self", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + i.Owner.Id.ToString() + "/Items/" + i.Id.ToString() });
                    i.Relations.Add("complete", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + i.Owner.Id.ToString() + "/Items/" + i.Id.ToString() + "/Complete" });
                    i.Relations.Add("incomplete", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + i.Owner.Id.ToString() + "/Items/" + i.Id.ToString() + "/Incomplete" });
                    i.Relations.Add("assign", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + i.Owner.Id.ToString() + "/Items/" + i.Id.ToString() + "/Assign" });
                }
            }

        }

        [Route("Users/{userid}/Items", Name="GetItems")]
        public IHttpActionResult GetItems(int userid) 
        {
            var items = _items.Where(i=>i.Owner.Id == userid);

            var itemsResourceList = new SimpleResourceList<Item>();
            itemsResourceList.Items = items.ToList();

            return Ok(items);            
        }

        [Route("Users/{userid}/Items/Open", Name = "GetOpenItems")]
        public IHttpActionResult GetOpenItems(int userid)
        {
            var items = _items.Where(i => i.Owner.Id == userid && i.Status == "open");

            var usersResourceList = new SimpleResourceList<Item>();
            usersResourceList.Items = items.ToList();

            return Ok(items);
        }

        [Route("Users/{userid}/Items/Closed", Name = "GetClosedItems")]
        public IHttpActionResult GetClosedItems(int userid) 
        {
            var items = _items.Where(i => i.Owner.Id == userid && i.Status == "closed");

            var usersResourceList = new SimpleResourceList<Item>();
            usersResourceList.Items = items.ToList();

            return Ok(items);            
        }

        [Route("Users/{userid}/Items/{itemid}", Name="GetItem")]
        public IHttpActionResult GetItem(int userid, int itemid) {

            var item = _items.FirstOrDefault(i => i.Id == itemid);
            return Ok(item);
        }

        [Route("Users/{userid}/Items/{itemid}/Complete", Name = "PutItemComplete")]
        public IHttpActionResult PutItemComplete(int userid, int itemid)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemid);
            if (item == null)
            {
                return NotFound();
            }

            item.IsComplete = true;
            return Ok();
        }

        [Route("Users/{userid}/Items/{itemid}/Incomplete", Name = "PutItemIncomplete")]
        public IHttpActionResult PutItemIncomplete(int userid, int itemid) {
            var item = _items.FirstOrDefault(i => i.Id == itemid);
            if (item == null)
            {
                return NotFound();
            }

            item.IsComplete = false;
            return Ok();
        }


        [Route("Users/{userid}/Items", Name="PostItem")]
        public IHttpActionResult PostItem(int userid, Item item)
        {
            item.Id = _items.Max(p => p.Id) + 1;
            
            item.Owner = UserController._users.FirstOrDefault(u => u.Id == userid);

            item.Relations.Add("self", new Link { Href = Url.Link("GetItem", new { userid=userid, itemid = item.Id }) });
            //item.Relations.Add("complete", new Link { Href = "http://restfesttodo.azurewebsites.net/User/" + item.Id.ToString() + "/Items/" + i.Id.ToString() + "/Complete" });
            //item.Relations.Add("incomplete", new Link { Href = "http://restfesttodo.azurewebsites.net/User/" + item.Id.ToString() + "/Items/" + i.Id.ToString() + "/Incomplete" });
            //item.Relations.Add("assign", new Link { Href = "http://restfesttodo.azurewebsites.net/User/" + i.Owner.Id.ToString() + "/Items/" + i.Id.ToString() + "/Assign" });

            _items.Add(item);
            return Created(Url.Link("GetItem", new { itemId = item.Id }), item);
        }

        [Route("Users/{userid}/Items/{itemid}/Assign")]
        public IHttpActionResult PutAssignment(int userid, int itemid, [FromBody]string username)
        {            
            var item = _items.FirstOrDefault(i => i.Id == itemid);
            if (item == null)
            {
                return NotFound();
            }

            var user = UserController._users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return BadRequest("Specified username not found");
            }

            item.AssignedTo = user;
            return Ok();
        }
    }
}
