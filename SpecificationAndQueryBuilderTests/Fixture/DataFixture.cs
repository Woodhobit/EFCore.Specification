using Demo.DAL.Models;
using SpecificationAndQueryBuilderTests.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecificationAndQueryBuilderTests.Fixture
{
    public class DataFixture : IDisposable
    {
        public IQueryable<Invoice> Invoices { get; }

        public DataFixture()
        {
            this.Invoices = this.GetInvoices().AsQueryable();
        }

        private List<Invoice> GetInvoices()
        {
            var customer1 = EntityFactory.GetCustomer(1, "cutromer1");
            var customer2 = EntityFactory.GetCustomer(2, "cutromer2");


            var lineItem1 = EntityFactory.GetInvoiceLine(1, "item1", 10, "unit", 1);
            var lineItem2 = EntityFactory.GetInvoiceLine(2, "item2", 11, "unit1", 2);
            var lineItem3 = EntityFactory.GetInvoiceLine(3, "item3", 5, "unit1", 4);
            var lineItem4 = EntityFactory.GetInvoiceLine(4, "item1", 10, "unit1", 4);

            var lineItems = new List<InvoiceLine> { lineItem1, lineItem2, lineItem3, lineItem4 };

            var invoice1Customer1Paid = EntityFactory.GetInvoice(1, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1), true, customer1, "12345", lineItems);
            var invoice2Customer1Unpaid = EntityFactory.GetInvoice(2, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(2), false, customer1, "45678", lineItems);
            var invoice3Customer1Unpaid = EntityFactory.GetInvoice(3, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(4), false, customer1, "12457", lineItems);

            var invoice4Customer2Paid = EntityFactory.GetInvoice(4, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(3), true, customer2, "13469", lineItems);
            var invoice5Customer2Paid = EntityFactory.GetInvoice(5, DateTime.Now.AddDays(-4), DateTime.Now.AddDays(2), true, customer2, "31658", lineItems);
            var invoice6Customer2Unpaid = EntityFactory.GetInvoice(6, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(4), false, customer2, "76195", lineItems);

            return new List<Invoice> 
            { 
                invoice1Customer1Paid, 
                invoice2Customer1Unpaid, 
                invoice3Customer1Unpaid,
                invoice4Customer2Paid, 
                invoice5Customer2Paid, 
                invoice6Customer2Unpaid };

        }

        public void Dispose()
        {
            this.Invoices.ToList().Clear();
        }
    }
}
