using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        #region Private, Consturctor and Dispose
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new Models.ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        } 
        #endregion

        #region HttpPost
            [HttpPost]
            public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var customerFormModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", customerFormModel);
            }


            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region HttpGet
            [HttpGet]
            public ActionResult Index()
            {
                var customers = _context.Customers.Include(c => c.MembershipType).ToList();

                return View(customers);
            }

            [HttpGet]
            [Route("customers/details/{id}")]
            public ActionResult Details(int id)
            {
                var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

                if (customer == null)
                    return HttpNotFound();

                return View(customer);
            }

            [HttpGet]
            public ActionResult New()
            {
                var membershipTypes = _context.MembershipTypes.ToList();
                var viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = membershipTypes
                };
                return View("CustomerForm", viewModel);
            }

            [HttpGet]
            public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }
        #endregion

    }
}