﻿using Demo.DAL.Models;
using Specification.Contract;
using System;
using System.Linq.Expressions;

namespace Demo.BLL.Specifications.Invoices
{
    class PaidInvoiceSpecification : CompositeSpecification<Invoice>
    {
        public override Expression<Func<Invoice, bool>> ToExpression()
        {
            return invoice => invoice.IsPaid == true;
        }
    }
}
