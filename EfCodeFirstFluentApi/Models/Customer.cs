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
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}