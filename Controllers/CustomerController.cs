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
        private NewOperation context;
       
        public CustomerController()
        {
            context = new NewOperation();
            
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

        public ActionResult Create()
        {
            CustomerModel model = new CustomerModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CustomerModel model)
        {
            try
            {
                Customer customer = new Customer()
                {
                    ReferenceId = model.ReferenceId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Mobile = model.Mobile
                    //Year = model.Year.ToString()
                };
                context.Customers.InsertOnSubmit(customer);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        public ActionResult Details(int id)
        {
            CustomerModel model = context.Customers.Where(x => x.ReferenceId == id).Select(x =>
                                                new CustomerModel()
                                                {
                                                    ReferenceId = x.ReferenceId,
                                                    FirstName = x.FirstName,
                                                    LastName = x.LastName,
                                                    Address = x.Address,
                                                    Mobile = x.Mobile
                                                }).SingleOrDefault();

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            CustomerModel model = context.Customers.Where(x => x.ReferenceId == id).Select(x =>
                                new CustomerModel()
                                {
                                    ReferenceId = x.ReferenceId,
                                    FirstName = x.FirstName,
                                    LastName = x.LastName,
                                    Address = x.Address,
                                    Mobile = x.Mobile
                                }).SingleOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CustomerModel model)
        {
            try
            {
                Customer customer = context.Customers.Where(x => x.ReferenceId == model.ReferenceId).Single<Customer>();
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.Address = model.Address;
                customer.Mobile = model.Mobile;
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        public ActionResult Delete(int id)
        {
            CustomerModel model = context.Customers.Where(x => x.ReferenceId == id).Select(x =>
                                new CustomerModel()
                                {
                                    ReferenceId = x.ReferenceId,
                                    FirstName = x.FirstName,
                                    LastName = x.LastName,
                                    Address = x.Address,
                                    Mobile = x.Mobile
                                }).SingleOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(CustomerModel model)
        {
            try
            {
                Customer customer = context.Customers.Where(x => x.ReferenceId == model.ReferenceId).Single<Customer>();
                context.Customers.DeleteOnSubmit(customer);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}
