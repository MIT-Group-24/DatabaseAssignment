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
       [Key]
        public int OrderNo { get; set; }
        
        public int Quantity { get; set; }


    }
}