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
        private static List<Category> _categories;

        public CategoryController()
        {
            if (_categories == null)
            {
                _categories = new List<Category>
                {
                    new Category
                    {
                        Id = 1,
                        Title = "Red"
                    },
                    new Category
                    {
                        Id = 2,
                        Title = "Green"
                    },
                    new Category
                    {
                        Id = 3,
                        Title = "Blue"
                    }
                };
            }
        }

        [Route("Categories", Name = "GetCategories")]
        public IHttpActionResult GetCategories() 
        {
            var usersResourceList = new SimpleResourceList<Category>();
            usersResourceList.Items = _categories;

            return Ok(usersResourceList);

        }

        [Route("Categories/{categoryid}", Name = "GetCategory")]
        public IHttpActionResult GetCategory(int categoryid)
        {
            var user = _categories.FirstOrDefault(u => u.Id == categoryid);

            return Ok(user);
        }

        [Route("Categories", Name = "PostCategories")]
        public IHttpActionResult PostCategory(Category category)
        {
            category.Id = _categories.Max(p => p.Id) + 1;
            _categories.Add(category);
            return Created(Url.Link("GetCategory", new { categoryId = category.Id }), category);
        }
    }
}
