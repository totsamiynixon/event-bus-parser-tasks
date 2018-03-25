using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(ITagsCounterTaskService service)
        {

        }
        // GET: Home
        public string Index()
        {
            return "322";
        }
    }
}