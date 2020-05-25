using Demo.DAL.Models;
using System;
using System.Collections.Generic;

namespace SpecificationAndQueryBuilderTests.Helper
{
    public class EntityFactory
    {
        public static Customer GetCustomer(long id, string name)
        {
            return new Customer 
            { 
                Id = id,
                Name = name
            };
        }

        public static InvoiceLine GetInvoiceLine(
            long id, 
            string lineItem, 
            double price, 
            string unit, 
            double amount, 
            Invoice invoice = null) 
        {
            return new InvoiceLine
            {
                Id = id,
                LineItem = lineItem,
                Price = price,
                Unit = unit,
                Amount = amount,
                Sum = amount * price,
                Invoice = invoice
            };
        }

        public static Invoice GetInvoice(
            long id, 
            DateTime date, 
            DateTime dueDate, 
            bool isPaid, 
            Customer customer, 
            string invoiceNo,
            IList<InvoiceLine> lines = null)
        {
            return new Invoice
            {
                Id = id,
                Date = date,
                DueDate = dueDate,
                IsPaid = isPaid,
                Customer = customer,
                InvoiceNo = invoiceNo,
                Lines = lines ?? new List<InvoiceLine>()
            };
        }
    }
}
