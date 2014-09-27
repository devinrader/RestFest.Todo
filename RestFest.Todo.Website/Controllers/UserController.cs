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
        public IRepository<User> _users;

        //TODO: Dependency injection
        //public UserController(IRepository<User> users)
        //{
        //    _users = users;    
        //}

        public UserController()
        {
            _users = Repository<User>.Instance;
        }

        [Route("Users", Name = "GetUsers")]
        public IHttpActionResult GetUsers() 
        { 
            var usersResourceList = new SimpleResourceList<User>();
            foreach (var u in _users.Select())
            {
                SetLinkRelations(u);
            }
            
            usersResourceList.Items = _users.Select().ToList();

            return Ok(usersResourceList);
        }

        [Route("Users", Name = "GetUsersByPhoneNumber")]
        public IHttpActionResult GetUsers(string phonenumber)
        {
            var usersResourceList = new SimpleResourceList<User>();
            usersResourceList.Items = _users.Select().Where(u => u.PhoneNumber == phonenumber).ToList();

            return Ok(usersResourceList);
        }

        [Route("Users/{userid}/", Name = "GetUser")]
        public IHttpActionResult GetUser(int userid)
        {
            var user = _users.Select().FirstOrDefault(u => u.Id == userid);

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
            user.Id = _users.Select().Max(p => p.Id) + 1;
            SetLinkRelations(user);
            
            _users.Add(user);
            return Created(Url.Link("GetUser", new {userId = user.Id}), user);
        }
    }
}
