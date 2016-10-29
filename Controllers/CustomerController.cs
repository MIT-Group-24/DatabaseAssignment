using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShopInventoryApp.Models;
namespace BookInventoryApp.Controllers
{
    public class CustomerController : Controller
    {
        private OperationDataContext context;
       
        public CustomerController()
        {
            context = new OperationDataContext();
            
        }
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            IList <CustomerModel> CustomerList = new List<CustomerModel>();
            var query = from customer in context.Customers
                       select customer;
            var customers = query.ToList();
            foreach (var customerdata in customers)
            {
                CustomerList.Add(new CustomerModel()
                {
                    ReferenceId = customerdata.ReferenceId,
                    FirstName = customerdata.FirstName,
                    LastName = customerdata.LastName,
                    Address = customerdata.Address,
                    Mobile = customerdata.Mobile
                });
            }
                   
            return View(CustomerList);
        }

    }
}
