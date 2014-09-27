using PointW.ResourceModel;
using RestFest.Todo.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace RestFest.Todo.Website
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Mock out data for the sample app.
            // TODO: Change the app to use Dependency Injection so we don't have to init the data here
            Repository<User>.Instance.AddRange(new User[] {
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
                });

            //TODO: Change the Resource base class 
            foreach (var u in Repository<User>.Instance.Select())
            {
                u.Relations.Add("self", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + u.Id.ToString() });
            }


            Repository<Category>.Instance.AddRange(new Category[] {
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
                });

            foreach (var c in Repository<Category>.Instance.Select())
            {
                c.Relations.Add("self", new Link { Href = "http://restfesttodo.azurewebsites.net/Categories/" + c.Id.ToString() });
            }

            Repository<Item>.Instance.AddRange(new Item[] {
                new Item
                    {
                        Id = 1,
                        Title = "foo",
                        Text="Todo this",
                        Owner=Repository<User>.Instance.Select().ElementAt(0),
                        Status = "open"

                    },
                    new Item
                    {
                        Id = 2,
                        Title = "bar",
                        Text="Todo that",
                        Owner=Repository<User>.Instance.Select().ElementAt(0),
                        Status = "closed"
                    },
                    new Item
                    {
                        Id = 3,
                        Title = "bleh",
                        Text="Todo stuff",
                        Owner=Repository<User>.Instance.Select().ElementAt(0),
                        Status="open"
                    }});


            foreach (var i in Repository<Item>.Instance.Select())
            {
                i.Relations.Add("self", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + i.Owner.Id.ToString() + "/Items/" + i.Id.ToString() });
                i.Relations.Add("complete", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + i.Owner.Id.ToString() + "/Items/" + i.Id.ToString() + "/Complete" });
                i.Relations.Add("incomplete", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + i.Owner.Id.ToString() + "/Items/" + i.Id.ToString() + "/Incomplete" });
                i.Relations.Add("assign", new Link { Href = "http://restfesttodo.azurewebsites.net/Users/" + i.Owner.Id.ToString() + "/Items/" + i.Id.ToString() + "/Assign" });
            }

        }
    }
}
