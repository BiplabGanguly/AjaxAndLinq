using Entity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace UserProfileSearch.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomers customer;
 
        public CustomerController(ICustomers customer)
        {
            this.customer = customer;
        }

        //create customer
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            string msg = this.customer.InsertCustomer(customer);
            TempData["msg"] = msg;
            return RedirectToAction("Index","Customer");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCustomers(string search, string filter)
        {
            List<Customer> customer = this.customer.GetAllCustomer();
            if (!string.IsNullOrEmpty(search))
            {
                int.TryParse(search, out int searchId);
                customer = customer.Where(c=> c.Id == searchId || c.FirstName.ToLower().Contains(search.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(filter))
            {
                customer = customer.Where(c => c.Id.ToString()==filter).ToList();
            }

            return Json(customer, JsonRequestBehavior.AllowGet);
        }

  
    }
}