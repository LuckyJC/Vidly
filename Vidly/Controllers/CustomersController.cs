using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //need to override dispose from the base controller class
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers at index route /customers
        public ActionResult Index()
        {
            //calling ToList() on _context.Customers will immediately execute the query on the customers dbset. Otherwise 
            //the query will not be executed until the customers object is iterated (in the View). This is called deferred execution.
            // .Include() is called eager loading and is including loading the MembershipType with the customer; need to 
            //include the using System.Data.Entity statement above to resolve the c.MembershipType error that arises from using .Include()
            //removing the call to get customers as this will be handled client-side with ajax
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(/*customers*/);

        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        //old hard coded method to provide values was replaced by _context.Customers
        //        private IEnumerable<Customer> GetCustomers()
        //        {
        //            return new List<Customer>
        //            {
        //                new Customer {Id = 1, Name = "Jimmy Carson"},
        //                new Customer {Id = 2, Name = "Cecile Carson"}
        //            };
        //        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                //initialize new empty customer to populate default value for Id which is 0
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //prevent CSRF attacks - cross site reference forgery; also use on actions ex:Save
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);

            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //Microsoft recommends TryUpdateModel but is not the best approach- this updates all properties
                //A better approach is choosing what you want to update and setting the properties individually or
                //using a library like AutoMapper (convention based mapping tool) to map the properties; Mapper.map(customer, customerInDb);
                //TryUpdateModel(customerInDb);

                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }

            //this will actually save changes to the database
            _context.SaveChanges();

            //redirect to the index of the customer controller
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);

        }
    }
}