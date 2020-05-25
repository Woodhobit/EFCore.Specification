using Demo.BLL.DTO;
using Demo.DAL.Models;
using Specification.Contract;
using System;
using System.Linq.Expressions;

namespace Demo.BLL.Specifications.Invoices
{
    public class SelectInvoiceSpecification : QueryProjection<Invoice, InvoiceDto>
    {
        public override Expression<Func<Invoice, InvoiceDto>> ToSelectExpression()
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
