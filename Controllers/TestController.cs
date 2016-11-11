using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShopInventoryApp.Models;

namespace BookShopInventoryApp.Controllers
{
    public class TestController : Controller
    {
        private NewOperation context;
        public TestController()
        {
            //OperationDataContext context = new OperationDataContext();
             context = new NewOperation();
        }

        private void PrepareBook(TestModel model)
        {
            model.Books = context.BOOKs.AsQueryable<BOOK>().Select(x =>
                new SelectListItem()
                {
                    Text = x.Title,
                    Value = x.Id.ToString()
                });
            model.Customers = context.Customers.AsQueryable<Customer>().Select(x =>
                new SelectListItem()
                {
                    Text = x.FirstName + " " + x.LastName,
                    Value = x.ReferenceId.ToString()
                });
        }

        public ActionResult Index()
        {
            IList<TestModel> TestList = new List<TestModel>();
            var query = from test in context.Tests
                        join book in context.BOOKs
                        on test.BookId equals book.Id
                        join customer in context.Customers
                        on test.CustomerId equals customer.ReferenceId
                        select new TestModel
                        {
                            Id = test.Id,
                            Quantity = test.Quantity,
                            BookName = book.Title,
                            OrderDate = test.OrderDate,
                            BookPrice = book.Price,
                            CustomerName = customer.FirstName + " " + customer.LastName
                        };
            TestList = query.ToList();
            return View(TestList);
        }
        public ActionResult Create()
        {
            TestModel model = new TestModel();
            PrepareBook(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(TestModel model)
        {
            try
            {
               var queryPrice = (from book in context.BOOKs
                                 where book.Id == model.BookId
                                 select book.Price);
                Test test = new Test()
                {
                    Quantity = model.Quantity,
                    BookId = model.BookId,
                    CustomerId = model.CustomerId,
                    OrderDate = model.OrderDate,
                    Price = queryPrice.First()
                };
                context.Tests.InsertOnSubmit(test);
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
