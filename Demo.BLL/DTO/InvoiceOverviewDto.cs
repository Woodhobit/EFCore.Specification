using System;

namespace Demo.BLL.DTO
{
    public class InvoiceOverviewDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string Customer { get; set; }
        public string Number { get; set; }
        public bool IsPaid { get; set; }
        public double TotalSum { get; set; }
    }
}
