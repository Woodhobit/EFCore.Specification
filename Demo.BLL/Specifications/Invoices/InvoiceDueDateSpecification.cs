using Demo.DAL.Models;
using Specification.Contract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Demo.BLL.Specifications.Invoices
{
    class InvoiceDueDateSpecification : Specification<Invoice>
    {
        private readonly DateTime dueDate;

        public InvoiceDueDateSpecification(DateTime dueDate)
        {
            this.dueDate = dueDate;
        }

        public override Expression<Func<Invoice, bool>> ToExpression()
        {
            return invoice => invoice.DueDate == this.dueDate;
        }
    }
}
