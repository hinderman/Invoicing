namespace InvoicingData.Model
{
    public class Product
    {
        public int Id { get; set; }

        public Category Category { get; set; }

        public string Description { get; set; }

        public string Barcode { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
