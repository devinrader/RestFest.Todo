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
        private IRepository<Item> _items;

        //TODO: Dependency injection
        //public ItemController(IRepository<Item> items)
        //{
        //    _items = items;    
        //}

        public ItemController()
        {
            _items = Repository<Item>.Instance;
        }

        [Route("Users/{userid}/Items", Name="GetItems")]
        public IHttpActionResult GetItems(int userid) 
        {
            var items = _items.Select().Where(i=>i.Owner.Id == userid);

            var itemsResourceList = new SimpleResourceList<Item>();
            itemsResourceList.Items = items.ToList();

            return Ok(items);            
        }

        [Route("Users/{userid}/Items/Open", Name = "GetOpenItems")]
        public IHttpActionResult GetOpenItems(int userid)
        {
            var items = _items.Select().Where(i => i.Owner.Id == userid && i.Status == "open");

            var usersResourceList = new SimpleResourceList<Item>();
            usersResourceList.Items = items.ToList();

            return Ok(items);
        }

        [Route("Users/{userid}/Items/Closed", Name = "GetClosedItems")]
        public IHttpActionResult GetClosedItems(int userid) 
        {
            var items = _items.Select().Where(i => i.Owner.Id == userid && i.Status == "closed");

            var usersResourceList = new SimpleResourceList<Item>();
            usersResourceList.Items = items.ToList();

            return Ok(items);            
        }

        [Route("Users/{userid}/Items/{itemid}", Name="GetItem")]
        public IHttpActionResult GetItem(int userid, int itemid) {

            var item = _items.Select().FirstOrDefault(i => i.Id == itemid);
            return Ok(item);
        }

        [Route("Users/{userid}/Items/{itemid}/Complete", Name = "PutItemComplete")]
        public IHttpActionResult PutItemComplete(int userid, int itemid)
        {
            var item = _items.Select().FirstOrDefault(i => i.Id == itemid);
            if (item == null)
            {
                return NotFound();
            }

            item.Status = "closed";
            item.IsComplete = true;
            return Ok();
        }

        [Route("Users/{userid}/Items/{itemid}/Incomplete", Name = "PutItemIncomplete")]
        public IHttpActionResult PutItemIncomplete(int userid, int itemid) {
            var item = _items.Select().FirstOrDefault(i => i.Id == itemid);
            if (item == null)
            {
                return NotFound();
            }

            item.Status = "open"; 
            item.IsComplete = false;
            return Ok();
        }


        [Route("Users/{userid}/Items", Name="PostItem")]
        public IHttpActionResult PostItem(int userid, Item item)
        {
            item.Id = _items.Select().Max(p => p.Id) + 1;
            
            item.Owner = Repository<User>.Instance.Select().FirstOrDefault(u => u.Id == userid);

            item.Relations.Add("self", new Link { Href = Url.Link("GetItem", new { userid=userid, itemid = item.Id }) });
            item.Relations.Add("complete", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + item.Owner.Id.ToString() + "/Items/" + item.Id.ToString() + "/Complete" });
            item.Relations.Add("incomplete", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + item.Owner.Id.ToString() + "/Items/" + item.Id.ToString() + "/Incomplete" });
            item.Relations.Add("assign", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + item.Owner.Id.ToString() + "/Items/" + item.Id.ToString() + "/Assign" });

            _items.Add(item);
            return Created(Url.Link("GetItem", new { itemId = item.Id }), item);
        }

        [Route("Users/{userid}/Items/{itemid}/Assign")]
        public IHttpActionResult PutAssignment(int userid, int itemid, [FromBody]string username)
        {            
            var item = _items.Select().FirstOrDefault(i => i.Id == itemid);
            if (item == null)
            {
                return NotFound();
            }

            var user = Repository<User>.Instance.Select().FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return BadRequest("Specified username not found");
            }

            item.AssignedTo = user;
            return Ok();
        }
    }
}
