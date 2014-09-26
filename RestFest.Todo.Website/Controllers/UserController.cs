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
                        Username = "psmith",
                        PhoneNumber = "13144586142"
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Darcy",
                        LastName = "Jones",
                        Username = "djones",
                        PhoneNumber = "15555555555"
                    },
                    new User
                    {
                        Id = 3,
                        FirstName = "Leslie",
                        LastName = "Neilson",
                        Username = "lneilson",
                        PhoneNumber = "15556666666"
                    }
                };
            }
        }

        [Route("Users", Name = "GetUsers")]
        public IHttpActionResult GetUsers() 
        { 
            var usersResourceList = new SimpleResourceList<User>();

            foreach (var u in _users)
            {
                SetLinkRelations(u);
                // u.Relations.Add("self", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + u.Id.ToString() });
            }
            
            usersResourceList.Items = _users;

            return Ok(usersResourceList);
        }

        [Route("Users", Name = "GetUsersByPhoneNumber")]
        public IHttpActionResult GetUsers(string phonenumber)
        {
            var usersResourceList = new SimpleResourceList<User>();
            usersResourceList.Items = _users.Where(u => u.PhoneNumber == phonenumber).ToList();

            return Ok(usersResourceList);
        }

        [Route("Users/{userid}/", Name = "GetUser")]
        public IHttpActionResult GetUser(int userid)
        {
            var user = _users.FirstOrDefault(u => u.Id == userid);

            SetLinkRelations(user);
            return Ok(user);
        }

        private void SetLinkRelations(User user)
        {
            AddUserIdBasedRelation(user, "self", "GetUser");
            AddUserIdBasedRelation(user, "items", "GetItems");
            AddUserIdBasedRelation(user, "openitems", "GetOpenItems");
            AddUserIdBasedRelation(user, "closeditems", "GetClosedItems");
        }

        private void AddUserIdBasedRelation(User user, string rel, string routeName)
        {
            if (!user.Relations.ContainsKey(rel))
            {
                user.Relations.Add(rel, new Link() {Href = Url.Link(routeName, new {userid = user.Id})});
            }
        }

        [Route("Users/", Name="PostUser")]
        public IHttpActionResult PostUser(User user)
        {
            user.Id = _users.Max(p => p.Id) + 1;
            // user.Relations.Add("self", new Link { Href = Url.Link("GetUser", new { userid = user.Id }) });
            SetLinkRelations(user);

            
            _users.Add(user);
            return Created(Url.Link("GetUser", new {userId = user.Id}), user);
        }
    }
}
