using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShopInventoryApp.Models;

namespace BookInventoryApp.Controllers
{
    public class BookController : Controller
    {
        private OperationDataContext context;

        public BookController()
        {
            context = new OperationDataContext();
        }

        private void PreparePublisher(BookModel model)
        {
            model.Publishers = context.Publishers.AsQueryable<Publisher>().Select(x =>
                    new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    });
        }

        public ActionResult Index()
        {
            IList<BookModel> BookList = new List<BookModel>();
            var query = from book in context.BOOKs
                        join publisher in context.Publishers
                        on book.PublisherId equals publisher.Id
                        select new BookModel
                        {
                            Id = book.Id,
                            Title = book.Title,
                            PublisherName = publisher.Name,
                            Author = book.Author,
                            Year = book.Year,
                            Price = book.Price
                        };
            BookList = query.ToList();
            return View(BookList);
        }

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
                                                    PublisherName = x.Publisher.Name
                                                }).SingleOrDefault();

            return View(model);
        }

        public ActionResult Create()
        {
            BookModel model = new BookModel();
            PreparePublisher(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookModel model)
        {
            try
            {
                BOOK book = new BOOK()
                {
                    Title = model.Title,
                    Author = model.Author,
                    Year = model.Year,
                    Price = model.Price,
                    PublisherId = model.PublisherId
                };
                context.BOOKs.InsertOnSubmit(book);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
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
        }
    }
}
