namespace Demo.DAL.Models
{
    public class InvoiceLine : BaseEntity
    {
        public string LineItem { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public double Amount { get; set; }
        public double Sum { get; set; }
        public Invoice Invoice { get; set; }
    }
}
