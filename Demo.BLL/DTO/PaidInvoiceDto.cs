using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BLL.DTO
{
    public class PaidInvoiceDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string Customer { get; set; }
        public string Number { get; set; }
    }
}
