using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            var customers = new List<Customer>()
            {
                new Models.Customer { Name="Arthur Larenas", Id = 1},
                new Models.Customer { Name = "Maite Sophia", Id = 2}
            };

            return View(customers);
        }

        [HttpGet]
        [Route("customers/details/{name}")]

        public ActionResult Details(string name)
        {
            var customer = new Customer()
            {
                Name = name
            };
            return View(customer);
        }

    }
}