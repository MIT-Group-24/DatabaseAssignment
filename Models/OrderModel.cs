using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.

namespace BookShopInventoryApp.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            Books = new List<SelectListItem>();
            Customers = new List<SelectListItem>();
        }
        [Key]
        public int OrderNo { get; set; }
        public int Quantity { get; set; }
        
        public DateTime OrderDate { get; set; }
        public int BookId { get; set; }
        public int CustomerReferenceId { get; set; }
        [DisplayName("Book"), Required]
        public IEnumerable<SelectListItem> Books { get; set; }
        [DisplayName("Customer"), Required]
        public IEnumerable<SelectListItem> Customers { get; set; }
        public string BookName { get; set; }
        public string CustomerName { get; set; }

    }
}