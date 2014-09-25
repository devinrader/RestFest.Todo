using RestFest.Todo.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PointW.ResourceModel;

namespace RestFest.Todo.Website.Controllers
{
    public class UserController : ApiController
    {
        public static List<User> _users;

        public UserController()
        {
            if (_users == null)
            {
                _users = new List<User>
                {
                    new User
                    {
                        Id = 1,
                        FirstName = "Pat",
                        LastName = "Smith",
                        Username = "psmith"
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Darcy",
                        LastName = "Jones",
                        Username = "djones"
                    },
                    new User
                    {
                        Id = 3,
                        FirstName = "Leslie",
                        LastName = "Neilson",
                        Username = "lneilson"
                    }
                };

                foreach (var u in _users)
                {
                    u.Relations.Add("self", new Link { Href = Url.Link("GetUser", new { userid = u.Id }) });
                }
            }
        }

        [Route("Users", Name = "GetUsers")]
        public IHttpActionResult GetUsers() 
        { 
            var usersResourceList = new SimpleResourceList<User>();
            usersResourceList.Items = _users;

            return Ok(usersResourceList);
        }

        [Route("Users/{userid}/", Name="GetUser")]
        public IHttpActionResult GetUser(int userid)
        {
            var user = _users.FirstOrDefault(u => u.Id == userid);
            user.Relations.Add("items", new Link() { Href = Url.Link("GetItems", new { userid = userid }) });
            user.Relations.Add("openitems", new Link() { Href = Url.Link("GetOpenItems", new { userid = userid }) });
            user.Relations.Add("closeditems", new Link() { Href = Url.Link("GetClosedItems", new { userid = userid }) });

            return Ok(user);
        }


        [Route("Users/", Name="PostUser")]
        public IHttpActionResult PostUser(User user)
        {
            user.Id = _users.Max(p => p.Id) + 1;
            user.Relations.Add("self", new Link { Href = Url.Link("GetUser", new { userid = user.Id }) });

            
            _users.Add(user);
            return Created(Url.Link("GetUser", new {userId = user.Id}), user);
        }
    }
}
