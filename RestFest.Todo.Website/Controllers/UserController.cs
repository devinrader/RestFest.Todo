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
        // TodoDataContext _context;
        private static List<User> _users;

        public UserController()
        {
            // _context = TodoDataContext.Current();
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
            }
        }

        [Route("Users", Name = "GetUsers")]
        public IHttpActionResult GetUsers() 
        { 
            // var users = _context.Users;

            var usersResourceList = new SimpleResourceList<User>();

            //var usersResourceList = new SimpleResourceList<User>();
            usersResourceList.Items = _users;

            return Ok(usersResourceList);
        }

        [Route("Users/{userid}/", Name="GetUser")]
        public User GetUser(int userid)
        {
            return _users.FirstOrDefault(u => u.Id == userid);
        }


        [Route("Users/", Name="PostUser")]
        public IHttpActionResult PostUser(User user)
        {
            user.Id = _users.Max(p => p.Id) + 1;
            _users.Add(user);
            return Created(Url.Link("GetUser", new {userId = user.Id}), user);
        }
    }
}
