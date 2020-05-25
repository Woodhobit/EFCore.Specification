using Demo.DAL.Models;
using Specification.Contract;
using System;
using System.Linq.Expressions;

namespace Demo.BLL.Specifications.Invoices
{
    public class InvoiceOrderedByDateSpecification : OrderBySpecification<Invoice>
    {
        public override Expression<Func<Invoice, object>> ToOrderByExpression()
        {
            return invoice => invoice.Date;
        }
    }
}
