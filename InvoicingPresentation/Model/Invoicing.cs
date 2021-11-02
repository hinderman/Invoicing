using System;

namespace InvoicingPresentation.Model
{
    public class Invoicing
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime Hour { get; set; }

        public Person Customer { get; set; }

        public Person Seller { get; set; }
    }
}
