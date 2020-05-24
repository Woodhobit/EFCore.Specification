using Demo.BLL.DTO;
using Demo.DAL.Models;
using QueryBuilder.Contract;
using System;
using System.Linq.Expressions;

namespace Demo.BLL.Specifications.Invoices
{
    public class SelectInvoiceSpecification : IQueryProjection<Invoice, InvoiceDto>
    {
        public Expression<Func<Invoice, InvoiceDto>> ToSelectExpression()
        {
            Expression<Func<Invoice, InvoiceDto>> selectExpression = invoice => new InvoiceDto
            {
                Id = invoice.Id,
                Date = invoice.Date,
                DueDate = invoice.DueDate,
                Customer = invoice.Customer.Name,
                Number = invoice.InvoiceNo
            };

            return selectExpression;
        }
    }
}
