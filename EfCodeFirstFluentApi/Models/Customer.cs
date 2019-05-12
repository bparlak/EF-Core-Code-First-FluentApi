using System;
using System.Collections.Generic;

namespace EfCodeFirstFluentApi
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}