using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopInventoryApp.Models
{
    public class TestModel
    {
        public TestModel()
        {
            Books = new List<SelectListItem>();
            Customers = new List<SelectListItem>();
            OrderDate = DateTime.Now;
           
        }
        [DisplayName("Order Number")]
        public int Id { get; set; }
       
        public int ? Quantity { get; set; }
        [ReadOnly(true)]
        public DateTime ? OrderDate { get; set; }
        public decimal BookPrice { get; set; }
        public int BookId { get; set; }
        public IEnumerable<SelectListItem> Books { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        public string BookName { get; set; }
        [DisplayName("Customer")]
        public int CustomerId { get; set; }
        [DisplayName("Customer")]
        public string CustomerName { get; set; }
        
    }
}