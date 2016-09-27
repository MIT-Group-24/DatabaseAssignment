using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopInventoryApp.Models
{
    public class PublisherModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
    }
}