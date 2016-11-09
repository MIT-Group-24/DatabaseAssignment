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
        //private DateTime? OrderDate = null;
        public DateTime OrderDate { get; set; }
        

        [DisplayName("Book"), Required]
        public int BookId { get; set; }
        [DisplayName("Customer"), Required]
        public int CustomerReferenceId { get; set; }
        
        public IEnumerable<SelectListItem> Books { get; set; }
        
        public IEnumerable<SelectListItem> Customers { get; set; }
        public string BookName { get; set; }
        public string CustomerName { get; set; }

    }
}