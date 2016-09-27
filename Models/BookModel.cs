using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopInventoryApp.Models
{
    public class BookModel
    {
        public BookModel()
         {
             Publishers = new List<SelectListItem>();
         }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Publisher")]
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public IEnumerable<SelectListItem> Publishers { get; set; }
        public int ISBN { get; set; }
        public int StockLevel { get; set; }
    }
    }
