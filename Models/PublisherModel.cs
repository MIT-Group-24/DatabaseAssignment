using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShopInventoryApp.Models
{
    public class PublisherModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Year { get; set; }
        [Required]
        public string Address { get; set; }
        [DisplayName("Phone Number"),Required]
        public string PhoneNumber { get; set; }
    }
}