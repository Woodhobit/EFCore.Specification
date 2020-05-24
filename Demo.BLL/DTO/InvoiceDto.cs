using System;

namespace Demo.BLL.DTO
{
    public class InvoiceDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string Customer { get; set; }
        public string Number { get; set; }
    }
}
