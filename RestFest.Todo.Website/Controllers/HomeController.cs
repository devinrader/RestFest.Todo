using PointW.ResourceModel;
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
        [Route("")]
        public IHttpActionResult Get()
        {
            var home = new Home();
            home.Relations.Add("categories", new Link() { Href= Url.Link("GetCategories", null) });
            home.Relations.Add("users", new Link() { Href = Url.Link("GetUsers", null) });

            return Ok(home);
        }



        [Route("Users/{userid}/Items")]
        public List<Item> GetItems(int userid) { return null; }

        [Route("Users/{userid}/Items/Closed", Name = "GetClosedItems")]
        public List<Item> GetClosedItems(int userid) { return null; }


        [Route("Users/{userid}/Items/{itemid}")]
        public List<User> GetItem(int userid, int itemid) { return null; }

        [Route("Users/{userid}/Items/{itemid}/Complete", Name="MakeItemComplete")]
        public List<User> GetCompletedItems(int userid, int itemid) { return null; }

        [Route("Users/{userid}/Items/{itemid}/Incomplete", Name="MakeItemIncomplete")]
        public List<User> GetUsers(int userid, int itemid) { return null; }    


    }
}
