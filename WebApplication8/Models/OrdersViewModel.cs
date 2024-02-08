using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    public class OrdersViewModel
    {
        public List<Order> Orders { get; set; }
        public DateTime TodaysDate { get; set; }
    }
}