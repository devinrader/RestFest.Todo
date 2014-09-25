using PointW.ResourceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestFest.Todo.Website.Models
{
    public class Home : Resource
    {
        public string Greeting { get; set; }
    }
}