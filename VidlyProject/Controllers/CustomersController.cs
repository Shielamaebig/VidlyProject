using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyProject.Models;
using VidlyProject.ViewModels; // To read the ViewModel(NewMovieModel)

namespace VidlyProject.Controllers
{
    public class CustomersController : Controller
    {
        private MainDbContext _context; 
        //reads database
        //_context = db.

        public CustomersController()
        {
            _context = new MainDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
           
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()

            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {   //these command doesnot save
            // if (!ModelState.IsValid) {var viewModel = new NewCustomerViewModel{Customer = customer, MembershipTypes = _context.MembershipTypes.ToList()};
           //     return View("CustomerForm", viewModel);} 
           

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                //Manual Declaration
                //Also we can do here the mapper
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ViewResult Index()
        { //LamdbaExpression  c=> c.MembershipType To get thru the Customer Model get the MembershipType 
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        { // All the data in customer customer = Id Each 
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            //if the system doesnt have any data
            if (customer == null)
                return HttpNotFound();
            //click the customer name will direct to customer save page with the data
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            //For each database in customer data each Id
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            
            var viewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}