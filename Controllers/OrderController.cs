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

        
        public ActionResult Index()
        {
            IList<OrderModel> OrderList = new List<OrderModel>();
            var query = from order in context.Orders
                        join BOOK in context.BOOKs
                        on order.BookId equals BOOK.Id
                        select new OrderModel
                        {
                            
                            Quantity = Convert.ToInt32(order.Quantity)
                            
                            //BookName = BOOK.Title
                            //CustomerName = 
                        };
            OrderList = query.ToList();
            return View(OrderList);
        }
        
        

        public ActionResult Create()
        {
            OrderModel model = new OrderModel();
            
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
