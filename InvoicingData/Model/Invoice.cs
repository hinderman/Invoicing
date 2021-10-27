using System;

namespace InvoicingData.Model
{
    public class Invoice
    {
        public int Id { get; set; }

        public DateTime MyProperty { get; set; }

        public DateTime Hour { get; set; }

        public Customer Customer { get; set; }

        public Seller Seller { get; set; }
    }
}
