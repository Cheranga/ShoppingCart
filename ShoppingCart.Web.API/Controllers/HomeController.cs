using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Infrastructure.UoW;

namespace ShoppingCart.Web.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUoW uow;

        public HomeController(IUoW uow)
        {
            this.uow = uow;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
