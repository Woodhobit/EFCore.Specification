using Demo.DAL.Models;
using Specification.Contract;
using System;
using System.Linq.Expressions;

namespace Demo.BLL.Specifications.Invoices
{
    public class UnpaidInvoiceSpecification : Specification<Invoice>
    {
        public override Expression<Func<Invoice, bool>> ToExpression()
        {
            return invoice => invoice.IsPaid == false;
        }
    }
}
