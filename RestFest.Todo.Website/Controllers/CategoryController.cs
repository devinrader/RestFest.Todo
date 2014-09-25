using RestFest.Todo.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestFest.Todo.Website.Controllers
{
    public class CategoryController : ApiController
    {
        [Route("Categories", Name = "GetCategories")]
        public IHttpActionResult GetCategories() 
        { 
            return null; 
        }

        [Route("Categories/{categoryid}", Name = "GetCategory")]
        public IHttpActionResult GetCategory(int categoryid)
        {
            return null;
        }

        [Route("Categories", Name = "PostCategories")]
        public IHttpActionResult PostCategory(Category category)
        {
            return null;
        }
    }
}
