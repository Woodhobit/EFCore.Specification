using Demo.DAL.Models;
using Specification.Contract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Demo.BLL.Specifications.Invoices
{
    class PaidInvoiceBycustomerSpecification : CompositeSpecification<Invoice>
    {
        private readonly string customer;
        public PaidInvoiceBycustomerSpecification(string customer)
        {
            this.customer = customer;
        }
        public override Expression<Func<Invoice, bool>> ToExpression()
        {
            return invoice => invoice.IsPaid == true && invoice.Customer.Name == this.customer;
        }
    }
}
