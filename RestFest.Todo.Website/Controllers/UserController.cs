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
        TodoDataContext _context;

        public UserController()
        {
            _context = TodoDataContext.Current();
        }

        [Route("Users", Name = "GetUsers")]
        public IHttpActionResult GetUsers() 
        { 
            var users = _context.Users; 

            var usersResourceList = new SimpleResourceList<User>();
            //usersResourceList.Items = users.Select(;

            return Ok(usersResourceList);
        }

        [Route("Users/{userid}/", Name="GetUser")]
        public User GetUser(int userid) { return null; }


        [Route("Users/", Name="PostUser")]
        public User PostUser(User category)
        {
            return null;
        }
    }
}
