using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public decimal Price { get; set; }
        [DisplayName("Publisher"),Required]
        public int PublisherId { get; set; }
        [DisplayName("Publisher"),Required]
        public string PublisherName { get; set; }
        [Required]
        public IEnumerable<SelectListItem> Publishers { get; set; }
        [Required]
        public string ISBN { get; set; }
        [DisplayName("Stock Level"),Required]
        public int StockLevel { get; set; }
    }
    }
