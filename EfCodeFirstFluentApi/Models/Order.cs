using System;

namespace EfCodeFirstFluentApi
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }

    }
}