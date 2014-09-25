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
        public List<Category> GetCategories() 
        { 
            return null; 
        }

        [Route("Categories/{categoryid}", Name = "GetCategory")]
        public Category GetCategory(int categoryid)
        {
            return null;
        }

        [Route("Categories", Name = "PostCategories")]
        public Category PostCategory(Category category)
        {
            return null;
        }
    }
}
