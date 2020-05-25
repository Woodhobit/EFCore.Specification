using Demo.DAL.Models;
using Specification.Contract;
using System;
using System.Linq.Expressions;

namespace Demo.BLL.Specifications.Invoices
{
    public class InvoiceDueDateSpecification : CompositeSpecification<Invoice>
    {
        private readonly DateTime dueDate;

        public InvoiceDueDateSpecification(DateTime dueDate)
        {
            this.dueDate = dueDate;
        }

        public override Expression<Func<Invoice, bool>> ToExpression()
        {
            return invoice => invoice.DueDate.Date == this.dueDate.Date;
        }
    }
}
