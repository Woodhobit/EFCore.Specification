using System;
using System.Collections.Generic;

namespace Demo.DAL.Models
{
    public class Invoice : BaseEntity
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public Customer Customer { get; set; }
        public string InvoiceNo { get; set; }
        public IList<InvoiceLine> Lines { get; set; }

        public Invoice()
        {
            Lines = new List<InvoiceLine>();
        }
    }
}
