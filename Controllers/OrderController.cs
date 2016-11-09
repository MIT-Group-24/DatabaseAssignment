using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShopInventoryApp.Models;

namespace BookInventoryApp.Controllers
{
    public class OrderController : Controller
    {
        private OperationDataContext context;

        public OrderController()
        {
            context = new OperationDataContext();
            
        }

        private void PrepareOrderDetails(OrderModel model)
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
                        Text = x.FirstName + x.LastName,
                        Value = x.ReferenceId.ToString()
                    });
        }

        public ActionResult Index()
        {
            IList<OrderModel> OrderList = new List<OrderModel>();
            var query = from order in context.Orders
                        join BOOK in context.BOOKs
                        on order.BookId equals BOOK.Id
                        select new OrderModel
                        {
                            OrderNo = order.OrderNo,
                            Quantity = order.Quantity,
                            OrderDate = order.OrderDate,
                            BookName = order.BookName,
                            CustomerName = order.CustomerName
                        };
            OrderList = query.ToList();
            return View(OrderList);
        }
        
        

        public ActionResult Create()
        {
            OrderModel model = new OrderModel();
            PrepareOrderDetails(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(OrderModel model)
        {
            try
            {
                Order order = new Order()
                {
                    Quantity = model.Quantity,
                    OrderDate = model.setDate(),
                    BookId = model.BookId,
                    CustomerReferenceId = model.CustomerReferenceId
                };
                context.Orders.InsertOnSubmit(order);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
        /*
         public ActionResult Details(int id)
        {
            BookModel model = context.BOOKs.Where(x => x.Id == id).Select(x =>
                                                new BookModel()
                                                {
                                                    Id = x.Id,
                                                    Title = x.Title,
                                                    Author = x.Author,
                                                    Price = x.Price,
                                                    Year = x.Year,
                                                    ISBN = x.ISBN,
                                                    StockLevel = x.StockLevel,
                                                    PublisherName = x.Publisher.Name
                                                }).SingleOrDefault();

            return View(model);
        }
         public ActionResult Edit(int id)
        {
            BookModel model = context.BOOKs.Where(x => x.Id == id).Select(x =>
                                new BookModel()
                                {
                                    Id = x.Id,
                                    Title = x.Title,
                                    Author = x.Author,
                                    Price = x.Price,
                                    Year = x.Year,
                                    ISBN = x.ISBN,
                                    StockLevel = x.StockLevel,
                                    PublisherName = x.Publisher.Name,
                                    PublisherId = x.PublisherId
                                }).SingleOrDefault();

            PreparePublisher(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookModel model)
        {
            try
            {

                BOOK book = context.BOOKs.Where(x => x.Id == model.Id).Single<BOOK>();
                book.Title = model.Title;
                book.Author = model.Author;
                book.Price = model.Price;
                book.Year = model.Year;
                book.ISBN = model.ISBN;
                book.StockLevel = model.StockLevel;
                book.PublisherId = model.PublisherId;
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

            BookModel model = context.BOOKs.Where(x => x.Id == id).Select(x =>
                                  new BookModel()
                                  {
                                      Id = x.Id,
                                      Title = x.Title,
                                      Author = x.Author,
                                      Price = x.Price,
                                      Year = x.Year,
                                      ISBN = x.ISBN,
                                      StockLevel = x.StockLevel,
                                      PublisherName = x.Publisher.Name
                                  }).SingleOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(BookModel model)
        {
            try
            {
                BOOK book = context.BOOKs.Where(x => x.Id == model.Id).Single<BOOK>();
                context.BOOKs.DeleteOnSubmit(book);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }*/
    }
}
