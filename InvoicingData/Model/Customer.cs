using System.Collections.Generic;

namespace InvoicingData.Model
{
    public class Customer
    {
        public int Document { get; set; }

        public IEnumerable<Phone> Phone { get; set; }

        public IEnumerable<Email> Email { get; set; }

        public IEnumerable<Address> Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
