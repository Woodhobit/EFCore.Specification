﻿using Demo.DAL.Models;
using Specification.Contract;
using System;
using System.Linq.Expressions;

namespace Demo.BLL.Specifications.Invoices
{
    class InvoiceByCustomerSpecification : Specification<Invoice>
    {
        private readonly string customer;

        public InvoiceByCustomerSpecification(string customer)
        {
            this.customer = customer;
        }

        public override Expression<Func<Invoice, bool>> ToExpression()
        {
            return invoice => invoice.Customer.Name.Contains(this.customer);
        }
    }
}
