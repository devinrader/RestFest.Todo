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
    public class CategoryController : ApiController
    {
        private IRepository<Category> _categories;

        //TODO: Dependency injection
        //public CategoryController(IRepository<Category> categories)
        //{
        //    _categories = categories;    
        //}
        
        public CategoryController()
        {
            _categories = Repository<Category>.Instance;                
        }

        [Route("Categories", Name = "GetCategories")]
        public IHttpActionResult GetCategories() 
        {
            var usersResourceList = new SimpleResourceList<Category>();
            usersResourceList.Items = _categories.Select().ToList(); ;

            return Ok(usersResourceList);

        }

        [Route("Categories/{categoryid}", Name = "GetCategory")]
        public IHttpActionResult GetCategory(int categoryid)
        {
            var user = _categories.Select().FirstOrDefault(u => u.Id == categoryid);

            return Ok(user);
        }

        [Route("Categories", Name = "PostCategory")]
        public IHttpActionResult PostCategory(Category category)
        {
            category.Id = _categories.Select().Max(p => p.Id) + 1;
            category.Relations.Add("self", new Link { Href = Url.Link("GetCategory", new { categoryid = category.Id }) });

            _categories.Add(category);
            return Created(Url.Link("GetCategory", new { categoryId = category.Id }), category);
        }
    }
}
